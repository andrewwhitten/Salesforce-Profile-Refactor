using System;
using System.IO;
using System.Collections.Generic;

namespace SalesforceProfileRefactor
{
    /// <summary>
    /// Create a CSV file (that can be imported into MS Excel or similar) that will help the user determine the extent of the changes.
    /// </summary>
    /// <remarks>There are many good Open Source CSV file serializers available. I avoided just to keep things simple, and no other reason.</remarks>
    public class ReportGenerator
    {

        /// <summary>
        /// Create a report from a list of Profiles
        /// </summary>
        /// <param name="type"></param>
        /// <param name="profiles"></param>
        /// <returns></returns>
        public static List<string> GenerateReportLineFromProfiles(string type, Dictionary<String, Profile> profiles)
        {
            List<string> outputStrings = new List<string>();

            foreach (KeyValuePair<String, Profile> profileKeyPair in profiles)
            {
                string profileReportLine = ReportGenerator.GenerateReportLineFromProfile(type, profileKeyPair.Key, profileKeyPair.Value);
                outputStrings.Add(profileReportLine);
            }

            return outputStrings;
        }

        /// <summary>
        /// Count the number of instances of each type of Profile section
        /// </summary>
        /// <param name="type">The type of Profile analyzed. Is it the input Profile, output Profile or other?</param>
        /// <param name="name"></param>
        /// <param name="profile"></param>
        /// <returns>A CSV formatted line of totals for each type</returns>
        public static string GenerateReportLineFromProfile(string type, string name, Profile profile)
        {
            int classAcccesses = profile.classAccesses is null ? 0 : profile.classAccesses.Length;
            int objectPermissions = profile.objectPermissions is null ? 0 : profile.objectPermissions.Length;
            int fieldPermissions = profile.fieldPermissions is null ? 0 : profile.fieldPermissions.Length;
            int layoutAssignments = profile.layoutAssignments is null ? 0 : profile.layoutAssignments.Length;
            int recordTypeVisibilities = profile.recordTypeVisibilities is null ? 0 : profile.recordTypeVisibilities.Length;
            int tabVisibilities = profile.tabVisibilities is null ? 0 : profile.tabVisibilities.Length;
            int customMetadataTypeAccesses = profile.customMetadataTypeAccesses is null ? 0 : profile.customMetadataTypeAccesses.Length;
            int customPermissions = profile.customPermissions is null ? 0 : profile.customPermissions.Length;
            int pageAccesses = profile.pageAccesses is null ? 0 : profile.pageAccesses.Length;
            int applicationVisibilities = profile.applicationVisibilities is null ? 0 : profile.applicationVisibilities.Length;
            int userPermissions = profile.userPermissions is null ? 0 : profile.userPermissions.Length;

            string stats = type + "," + name + "," 
                + classAcccesses + ","
                + objectPermissions + ","
                + fieldPermissions + ","
                + layoutAssignments + ","
                + recordTypeVisibilities + ","
                + tabVisibilities + ","
                + customMetadataTypeAccesses + ","
                + customPermissions + ","
                + pageAccesses + ","
                + applicationVisibilities + ","
                + userPermissions;

            return stats;
        }

        /// <summary>
        /// Create the CSV file
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <param name="inputLines"></param>
        public static void GenerateReport(DirectoryInfo directoryInfo, List<string> inputLines)
        {
            List<string> csvOutput = new List<string>();

            String reportFile = directoryInfo.FullName + Path.DirectorySeparatorChar + "Report.csv";

            string fileHeader = "Type, File Name, ClassAccesses, Object Permissions, Field Permissions, Layout Assignments, RecordType Visibilities, Tab Visibilities, Custom Metadata Datatype Accesses, Custom Permissions, Page Accesses, Application Visibilities, User Permissions";

            csvOutput.Add(fileHeader);
            csvOutput.AddRange(inputLines);

            System.IO.File.WriteAllLines(reportFile, csvOutput);
        }

    }
}
