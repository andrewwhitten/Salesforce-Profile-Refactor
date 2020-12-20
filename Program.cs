using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace SalesforceProfileRefactor
{
    /// <summary>
    /// Main class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;

            String mainProfileFile, sourceProfileFolder, destinationProfileFolder;

            List<String> profileFiles = new List<string>();

            if (args.Length == 0)
            {
                // Display message to user to provide parameters.
                System.Console.WriteLine("No parameters entered. Please enter an input and destination folder/directory");
                Console.Read();
            }
            else if (args.Length < 2)
            {
                // Display message to user to provide parameters.
                System.Console.WriteLine("Only one parameters entered. Please enter both an input and destination folder/directory");
                Console.Read();
            }
            else
            {
                sourceProfileFolder = args[0];

                // Source directory must existy
                if (!Directory.Exists(sourceProfileFolder))
                {
                    System.Console.WriteLine("Source folder/directory does not exist");
                    Console.Read();
                    return;         // No further program execution
                }

                destinationProfileFolder = args[1];

                // Destination directory must exist
                if (!Directory.Exists(destinationProfileFolder))
                {
                    System.Console.WriteLine("Destination folder/directory does not exist");
                    Console.Read();
                    return;         // No further program execution
                }

                string[] files = Directory.GetFiles(sourceProfileFolder, "*.xml", SearchOption.TopDirectoryOnly);

                if (files.Length == 0)
                {
                    // Profile files must end in XML
                    System.Console.WriteLine("Source folder/directory does not have any XML files");
                    Console.Read();
                    return;         // No further program execution

                }
                else
                {
                    // Set first file
                    mainProfileFile = files[0];
                    System.Console.WriteLine("Source file " + mainProfileFile + " added");

                    // Loop through the rest of the array to list args parameters.
                    for (int i = 1; i < files.Length; i++)
                    {
                        string file = files[i];
                        profileFiles.Add(file);
                        System.Console.WriteLine("Source file " + file + " added");
                    }

                    // Check that all input files actually exist
                    Boolean existCheck = File.Exists(mainProfileFile);
                    Boolean allFilesExist = true;

                    if (!existCheck)
                    {
                        Console.WriteLine("Parameter error. File does not exist: " + mainProfileFile);
                        Console.Read();
                    }
                    else
                    {
                        // Ensure all files exist
                        foreach (String s in profileFiles)
                        {
                            allFilesExist = File.Exists(s);

                            if (!allFilesExist)
                            {
                                allFilesExist = false;
                                Console.WriteLine("Parameter error. File does not exist: " + s);
                                Console.Read();
                            }
                        }

                        if (allFilesExist)
                        {
                            // Main execution point
                            Console.WriteLine("Let's wrangle some profiles!");
                            Program.GenerateFiles(mainProfileFile, profileFiles, destinationProfileFolder);
                        }
                    }
                }

                // Let user know the duration
                Console.WriteLine("Profile wrangling ran for: " + Helper.getDuration(start) + " seconds");
            }
        }


        /// <summary>
        /// Method that runs all the comparison and creation logic
        /// </summary>
        /// <param name="mainProfileFile"></param>
        /// <param name="compareFiles"></param>
        /// <param name="destinationProfileFolder"></param>
        private static void GenerateFiles(String mainProfileFile, List<String> compareFiles, String destinationProfileFolder)
        {
            String uniqueFilePart = Helper.CreateUniqueFileNamePart();

            // Our output profile
            Profile subSetProfileDocument, mainProfileSetDocument;

            Dictionary<String, Profile> comparisionProfiles = Helper.LoadComparisonProfiles(compareFiles);

            // Open the main Profile to compare
            using (var fileStream = File.Open(mainProfileFile, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Profile));
                mainProfileSetDocument = (Profile)serializer.Deserialize(fileStream);
            }

            if (mainProfileSetDocument != null)
            {
                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(destinationProfileFolder + Path.DirectorySeparatorChar + uniqueFilePart);

                System.Console.WriteLine("Output path is: " + di.FullName);

                subSetProfileDocument = SalesforceProfileBuilder.ProfileWithCommonElements(mainProfileSetDocument, comparisionProfiles);

                string subsetProfileFileName = di.FullName + Path.DirectorySeparatorChar + "SubsetPermissionSet.permissionset-meta.xml";

                if (SalesforcePermissionSetBuilder.GeneratePermissionSet(subsetProfileFileName, subSetProfileDocument))
                {

                    System.Console.WriteLine("Common Subset File Generated");

                    // Generate updated Profiles
                    comparisionProfiles.Add(mainProfileFile, mainProfileSetDocument);

                    List<string> inputFilesReportLines = ReportGenerator.GenerateReportLineFromProfiles("input", comparisionProfiles);

                    string outputCommonFile = ReportGenerator.GenerateReportLineFromProfile("common", subsetProfileFileName, subSetProfileDocument);

                    Dictionary<String, Profile> newReducedProfiles = SalesforceProfileRemoval.ProfileWithCommonElementsRemoved(subSetProfileDocument, comparisionProfiles);

                    // For the report
                    Dictionary<String, Profile> outputReportProfiles = new Dictionary<String, Profile>();


                    foreach (KeyValuePair<String, Profile> newProfile in newReducedProfiles)
                    {
                        String newFileName = Path.GetFileName(newProfile.Key);
                        String newFullFileName = di.FullName + Path.DirectorySeparatorChar + newFileName;

                        using (var fileStreamNew = File.Create(newFullFileName))
                        {
                            XmlSerializer serializerOutputNew = new XmlSerializer(typeof(Profile));
                            serializerOutputNew.Serialize(fileStreamNew, newProfile.Value);
                        }

                        // Profile with its name and new location.
                        outputReportProfiles.Add(newFullFileName, newProfile.Value);

                    }

                    System.Console.WriteLine("Updated Profile files Generated");

                    List<string> outputFilesReportLines = ReportGenerator.GenerateReportLineFromProfiles("output", outputReportProfiles);

                    // Report to write to CSV
                    List<string> fullReport = new List<string>();
                    fullReport.AddRange(inputFilesReportLines);
                    fullReport.Add(outputCommonFile);
                    fullReport.AddRange(outputFilesReportLines);

                    ReportGenerator.GenerateReport(di, fullReport);

                    SalesforceProfilePostRecreate.RecreateProfiles(di, newReducedProfiles, subSetProfileDocument, comparisionProfiles);

                    System.Console.WriteLine("Recreated Profile files Generated");
                }
                else
                {
                    System.Console.WriteLine("Common Subset File failed to build");
                }
            }
        }


    }
}

