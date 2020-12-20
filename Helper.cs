using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace SalesforceProfileRefactor
{
    public class Helper
    {
        /// <summary>
        /// Load all files specified as Profiles
        /// </summary>
        /// <param name="files"></param>
        /// <returns>A list of Profile objects and their related file names</returns>
        public static Dictionary<String, Profile> LoadComparisonProfiles(List<String> files)
        {
            Dictionary<String, Profile> comparisonProfiles = new Dictionary<String, Profile>();

            foreach (String file in files)
            {
                using (var fileStreamCompare = File.Open(file, FileMode.Open))
                {
                    XmlSerializer serializerCompare = new XmlSerializer(typeof(Profile));
                    var document = (Profile)serializerCompare.Deserialize(fileStreamCompare);

                    comparisonProfiles.Add(file, document);
                }
            }

            return comparisonProfiles;
        }

        /// <summary>
        /// Make a part of a file name with the current date and time
        /// </summary>
        /// <returns>String representation on the current data and time</returns>
        public static String CreateUniqueFileNamePart()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;

            String uniquePart = year.ToString() + "-" + month.ToString() + "-" + day.ToString() + " " + hour.ToString() + "-" + minute.ToString() + "-" + second.ToString();

            return uniquePart;
        }


        /// <summary>
        /// Return value in seconds between now and the specified start time
        /// </summary>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public static double getDuration(DateTime startTime)
        {
            DateTime end = DateTime.Now;
            double timeMS = end.Subtract(startTime).TotalMilliseconds;  // How many millisecords between the start of the process and now?
            double timeS = timeMS / 1000;                           // Convert milliseconds to seconds
            double displayValue = Math.Round(timeS, 2);

            return displayValue;
        }


    }
}
