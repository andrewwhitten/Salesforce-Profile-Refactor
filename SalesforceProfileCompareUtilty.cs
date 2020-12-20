using System;
using System.Collections.Generic;

namespace SalesforceProfileRefactor
{
    /// <summary>
    /// 
    /// </summary>
    class SalesforceProfileCompareUtilty
    {

       /* public static Boolean DoesItemExistInComparisonProfiles2<T>(Dictionary<String, Profile> comparisonProfiles, T profileAttribute)
        {
            Boolean commonElement = false;

            foreach (KeyValuePair<String, Profile> compareProfile in comparisonProfiles)
            {
                commonElement = compareProfile.Value.Exists(profileAttribute as typeof(T));

                if (!commonElement)
                {
                    break; // If fail to match once in any Profile, no need to keep looking in subsequent Profiles
                }
            }

            return commonElement;
        }*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparisonProfiles"></param>
        /// <param name="profileClassAccesses"></param>
        /// <returns></returns>
        public static Boolean DoesItemExistInComparisonProfiles(Dictionary<String, Profile> comparisonProfiles, ProfileClassAccesses profileClassAccesses)
        {
            Boolean commonElement = false;

            foreach (KeyValuePair<String, Profile> compareProfile in comparisonProfiles)
            {
                commonElement = compareProfile.Value.Exists(profileClassAccesses);

                if (!commonElement)
                {
                    break; // If fail to match once in any Profile, no need to keep looking in subsequent Profiles
                }
            }

            return commonElement;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparisonProfiles"></param>
        /// <param name="profileFieldPermissions"></param>
        /// <returns></returns>
        public static Boolean DoesItemExistInComparisonProfiles(Dictionary<String, Profile> comparisonProfiles, ProfileFieldPermissions profileFieldPermissions)
        {
            Boolean commonElement = false;

            foreach (KeyValuePair<String, Profile> compareProfile in comparisonProfiles)
            {
                commonElement = compareProfile.Value.Exists(profileFieldPermissions); 

                if (!commonElement)
                {
                    break; // If fail to match once in any Profile, no need to keep looking in subsequent Profiles
                }
            }

            return commonElement;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparisonProfiles"></param>
        /// <param name="profileLayoutAssignments"></param>
        /// <returns></returns>
        public static Boolean DoesItemExistInComparisonProfiles(Dictionary<String, Profile> comparisonProfiles, ProfileLayoutAssignments profileLayoutAssignments)
        {
            Boolean commonElement = false;

            foreach (KeyValuePair<String, Profile> compareProfile in comparisonProfiles)
            {
                commonElement = compareProfile.Value.Exists(profileLayoutAssignments);

                if (!commonElement)
                {
                    break; // If fail to match once in any Profile, no need to keep looking in subsequent Profiles
                }
            }

            return commonElement;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparisonProfiles"></param>
        /// <param name="profileRecordTypeVisibilities"></param>
        /// <returns></returns>
        public static Boolean DoesItemExistInComparisonProfiles(Dictionary<String, Profile> comparisonProfiles, ProfileRecordTypeVisibilities profileRecordTypeVisibilities)
        {
            Boolean commonElement = false;

            foreach (KeyValuePair<String, Profile> compareProfile in comparisonProfiles)
            {
                commonElement = compareProfile.Value.Exists(profileRecordTypeVisibilities);  

                if (!commonElement)
                {
                    return false; // If fail to match once in any Profile, no need to keep looking in subsequent Profiles
                }
            }

            return commonElement;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparisonProfiles"></param>
        /// <param name="profileTabVisibilities"></param>
        /// <returns></returns>
        public static Boolean DoesItemExistInComparisonProfiles(Dictionary<String, Profile> comparisonProfiles, ProfileTabVisibilities profileTabVisibilities)
        {
            Boolean commonElement = false;

            foreach (KeyValuePair<String, Profile> compareProfile in comparisonProfiles)
            {
                commonElement = compareProfile.Value.Exists(profileTabVisibilities); 

                if (!commonElement)
                {
                    break; // If fail to match once in any Profile, no need to keep looking in subsequent Profiles
                }
            }

            return commonElement;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparisonProfiles"></param>
        /// <param name="profileObjectPermissions"></param>
        /// <returns></returns>
        public static Boolean DoesItemExistInComparisonProfiles(Dictionary<String, Profile> comparisonProfiles, ProfileObjectPermissions profileObjectPermissions)
        {
            Boolean commonElement = false;

            foreach (KeyValuePair<String, Profile> compareProfile in comparisonProfiles)
            {
                commonElement = compareProfile.Value.Exists(profileObjectPermissions); 

                if (!commonElement)
                {
                    break; // If fail to match once in any Profile, no need to keep looking in subsequent Profiles
                }
            }

            return commonElement;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparisonProfiles"></param>
        /// <param name="profileCustomMetadataTypeAccesses"></param>
        /// <returns></returns>
        public static Boolean DoesItemExistInComparisonProfiles(Dictionary<String, Profile> comparisonProfiles, ProfileCustomMetadataTypeAccesses profileCustomMetadataTypeAccesses)
        {
            Boolean commonElement = false;

            foreach (KeyValuePair<String, Profile> compareProfile in comparisonProfiles)
            {
                commonElement = compareProfile.Value.Exists(profileCustomMetadataTypeAccesses); 

                if (!commonElement)
                {
                    break; // If fail to match once in any Profile, no need to keep looking in subsequent Profiles
                }
            }

            return commonElement;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparisonProfiles"></param>
        /// <param name="profileCustomPermissions"></param>
        /// <returns></returns>
        public static Boolean DoesItemExistInComparisonProfiles(Dictionary<String, Profile> comparisonProfiles, ProfileCustomPermissions profileCustomPermissions)
        {
            Boolean commonElement = false;

            foreach (KeyValuePair<String, Profile> compareProfile in comparisonProfiles)
            {
                commonElement = compareProfile.Value.Exists(profileCustomPermissions);  

                if (!commonElement)
                {
                    break; // If fail to match once in any Profile, no need to keep looking in subsequent Profiles
                }
            }

            return commonElement;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparisonProfiles"></param>
        /// <param name="profilePageAccesses"></param>
        /// <returns></returns>
        public static Boolean DoesItemExistInComparisonProfiles(Dictionary<String, Profile> comparisonProfiles, ProfilePageAccesses profilePageAccesses)
        {
            Boolean commonElement = false;

            foreach (KeyValuePair<String, Profile> compareProfile in comparisonProfiles)
            {
                commonElement = compareProfile.Value.Exists(profilePageAccesses);  

                if (!commonElement)
                {
                    break; // If fail to match once in any Profile, no need to keep looking in subsequent Profiles
                }
            }

            return commonElement;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparisonProfiles"></param>
        /// <param name="profileApplicationVisibilities"></param>
        /// <returns></returns>
        public static Boolean DoesItemExistInComparisonProfile(Dictionary<String, Profile> comparisonProfiles, ProfileApplicationVisibilities profileApplicationVisibilities)
        {
            Boolean commonElement = false;

            foreach (KeyValuePair<String, Profile> compareProfile in comparisonProfiles)
            {
                commonElement = compareProfile.Value.Exists(profileApplicationVisibilities);  

                if (!commonElement)
                {
                    break; // If fail to match once in any Profile, no need to keep looking in subsequent Profiles
                }
            }

            return commonElement;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparisonProfiles"></param>
        /// <param name="profileUserPermissions"></param>
        /// <returns></returns>
        public static Boolean DoesItemExistInComparisonProfiles(Dictionary<String, Profile> comparisonProfiles, ProfileUserPermissions profileUserPermissions)
        {
            Boolean commonElement = false;

            foreach (KeyValuePair<String, Profile> compareProfile in comparisonProfiles)
            {
                commonElement = compareProfile.Value.Exists(profileUserPermissions); 

                if (!commonElement)
                {
                    break; // If fail to match once in any Profile, no need to keep looking in subsequent Profiles
                }
            }

            return commonElement;

        }


    }
}




