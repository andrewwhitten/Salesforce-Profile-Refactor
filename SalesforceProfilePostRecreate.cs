using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace SalesforceProfileRefactor
{
    /// <summary>
    /// We want to recreate the origional profiles in order to be completely sure everything has been created correctly.
    /// If there are differences between the origional and the recreated Profile, then quite possibly something has gone wrong.
    /// </summary>
    public static class SalesforceProfilePostRecreate
    {
        /// <summary>
        /// Add two arrays togetger, and then sort into order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        private static T[] Concat<T>(this T[] first, T[] second)
        {
            if (first == null)
            {
                return second;
            }
            if (second == null)
            {
                return first;
            }

            List<T> list = new List<T>(first.Length + second.Length);
            list.AddRange(first);
            list.AddRange(second);

            // Ensure list is sorted. Not that the class being compared must have a 'CompareTo' method defined.
            list.Sort(); 

            // catchh 

            return list.ToArray();
        }


        /// <summary>
        /// Recreate Profiles - for validation after generation
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <param name="reducedProfiles"></param>
        /// <param name="commonProfile"></param>
        /// <param name="origionalProfiles"></param>
        static public void RecreateProfiles(DirectoryInfo directoryInfo, Dictionary<String, Profile> reducedProfiles, Profile commonProfile, Dictionary<String, Profile> origionalProfiles)
        {
            DirectoryInfo di2 = Directory.CreateDirectory(directoryInfo.FullName + Path.DirectorySeparatorChar + "Recreated");

            foreach (KeyValuePair<String, Profile> newProfile in reducedProfiles)
            {
                ProfileApplicationVisibilities[] array1 = newProfile.Value.applicationVisibilities;
                ProfileApplicationVisibilities[] array2 = commonProfile.applicationVisibilities;
                newProfile.Value.applicationVisibilities = SalesforceProfilePostRecreate.Concat<ProfileApplicationVisibilities>(array1, array2);

                ProfileCategoryGroupVisibilities[] array3 = newProfile.Value.categoryGroupVisibilities;
                ProfileCategoryGroupVisibilities[] array4 = commonProfile.categoryGroupVisibilities;
                newProfile.Value.categoryGroupVisibilities = SalesforceProfilePostRecreate.Concat<ProfileCategoryGroupVisibilities>(array3, array4);

                ProfileClassAccesses[] array5 = newProfile.Value.classAccesses;
                ProfileClassAccesses[] array6 = commonProfile.classAccesses;
                newProfile.Value.classAccesses = SalesforceProfilePostRecreate.Concat<ProfileClassAccesses>(array5, array6);

                ProfileCustomMetadataTypeAccesses[] array7 = newProfile.Value.customMetadataTypeAccesses;
                ProfileCustomMetadataTypeAccesses[] array8 = commonProfile.customMetadataTypeAccesses;
                newProfile.Value.customMetadataTypeAccesses = SalesforceProfilePostRecreate.Concat<ProfileCustomMetadataTypeAccesses>(array7, array8);

                ProfileCustomPermissions[] array9 = newProfile.Value.customPermissions;
                ProfileCustomPermissions[] array10 = commonProfile.customPermissions;
                newProfile.Value.customPermissions = SalesforceProfilePostRecreate.Concat<ProfileCustomPermissions>(array9, array10);

                ProfileFieldPermissions[] array11 = newProfile.Value.fieldPermissions;
                ProfileFieldPermissions[] array12 = commonProfile.fieldPermissions;
                newProfile.Value.fieldPermissions = SalesforceProfilePostRecreate.Concat<ProfileFieldPermissions>(array11, array12);

                ProfileLayoutAssignments[] array13 = newProfile.Value.layoutAssignments;
                ProfileLayoutAssignments[] array14 = commonProfile.layoutAssignments;
                newProfile.Value.layoutAssignments = SalesforceProfilePostRecreate.Concat<ProfileLayoutAssignments>(array13, array14);

                ProfileLoginIpRanges[] array15 = newProfile.Value.loginIpRanges;
                ProfileLoginIpRanges[] array16 = commonProfile.loginIpRanges;
                newProfile.Value.loginIpRanges = SalesforceProfilePostRecreate.Concat<ProfileLoginIpRanges>(array15, array16);

                ProfileObjectPermissions[] array17 = newProfile.Value.objectPermissions;
                ProfileObjectPermissions[] array18 = commonProfile.objectPermissions;
                newProfile.Value.objectPermissions = SalesforceProfilePostRecreate.Concat<ProfileObjectPermissions>(array17, array18);

                ProfilePageAccesses[] array19 = newProfile.Value.pageAccesses;
                ProfilePageAccesses[] array20 = commonProfile.pageAccesses;
                newProfile.Value.pageAccesses = SalesforceProfilePostRecreate.Concat<ProfilePageAccesses>(array19, array20);

                ProfileRecordTypeVisibilities[] array21 = newProfile.Value.recordTypeVisibilities;
                ProfileRecordTypeVisibilities[] array22 = commonProfile.recordTypeVisibilities;
                newProfile.Value.recordTypeVisibilities = SalesforceProfilePostRecreate.Concat<ProfileRecordTypeVisibilities>(array21, array22);


                // Tab Visibilities
                ProfileTabVisibilities[] array23 = newProfile.Value.tabVisibilities;
                ProfileTabVisibilities[] array24 = commonProfile.tabVisibilities;

                ProfileTabVisibilities[] profileTabVisibilitiesArray = SalesforceProfilePostRecreate.Concat<ProfileTabVisibilities>(array23, array24);
                List<ProfileTabVisibilities> profileTabVisibilitiesList = new List<ProfileTabVisibilities>(profileTabVisibilitiesArray);
                profileTabVisibilitiesList.Sort();
                newProfile.Value.tabVisibilities = profileTabVisibilitiesList.ToArray();


                //newProfile.Value.tabVisibilities = SalesforceProfilePostRecreate.Concat<ProfileTabVisibilities>(array23, array24);

                ProfileUserPermissions[] array25 = newProfile.Value.userPermissions;
                ProfileUserPermissions[] array26 = commonProfile.userPermissions;
                newProfile.Value.userPermissions = SalesforceProfilePostRecreate.Concat<ProfileUserPermissions>(array25, array26);

                String newFileName = Path.GetFileName(newProfile.Key);
                String recreatedFile = di2.FullName + Path.DirectorySeparatorChar + "recreated-" + newFileName;

                using (var fileStreamNew = File.Create(recreatedFile))
                {
                    XmlSerializer serializerOutputNew = new XmlSerializer(typeof(Profile));
                    serializerOutputNew.Serialize(fileStreamNew, newProfile.Value);
                }

            }

            foreach (KeyValuePair<String, Profile> newProfile in origionalProfiles)
            {
                String newFileName = Path.GetFileName(newProfile.Key);
                String recreatedFile = di2.FullName + Path.DirectorySeparatorChar + "origional-" + newFileName;

                using (var fileStreamNew = File.Create(recreatedFile))
                {
                    XmlSerializer serializerOutputNew = new XmlSerializer(typeof(Profile));
                    serializerOutputNew.Serialize(fileStreamNew, newProfile.Value);
                }
            }
        }
    }
}
