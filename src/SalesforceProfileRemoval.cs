using System;
using System.Collections.Generic;

namespace SalesforceProfileRefactor
{
    /// <summary>
    /// 
    /// </summary>
    public class SalesforceProfileRemoval
    {
        /// <summary>
        /// Remove common elements from origional Profiles
        /// </summary>
        /// <param name="commonElementProfile"></param>
        /// <param name="comparisionProfiles"></param>
        /// <returns></returns>
        static public Dictionary<String, Profile> ProfileWithCommonElementsRemoved(Profile commonElementProfile, Dictionary<String, Profile> comparisionProfiles)
        {
            Dictionary<String, Profile> updatedProfiles = new Dictionary<string, Profile>();

            foreach (KeyValuePair<String, Profile> profileKeyValuePair in comparisionProfiles)
            {
                Profile profile = UpdateProfile(commonElementProfile, profileKeyValuePair.Value);

                updatedProfiles.Add(profileKeyValuePair.Key, profile);
            }

            return updatedProfiles;
        }

        /// <summary>
        /// Update each Profile by removing Common Elements
        /// </summary>
        /// <param name="commonElementProfile"></param>
        /// <param name="profile"></param>
        /// <returns></returns>
        static private Profile UpdateProfile(Profile commonElementProfile,  Profile profile)
        {
            List<ProfileClassAccesses> newClassAccesses = new List<ProfileClassAccesses>();
            List<ProfileFieldPermissions> newFieldPermissions = new List<ProfileFieldPermissions>();
            List<ProfileLayoutAssignments> newLayoutAssignments = new List<ProfileLayoutAssignments>();
            List<ProfileRecordTypeVisibilities> newRecordTypeVisibilities = new List<ProfileRecordTypeVisibilities>();
            List<ProfileTabVisibilities> newTabVisibilities = new List<ProfileTabVisibilities>();
            List<ProfileObjectPermissions> newObjectPermissions = new List<ProfileObjectPermissions>();
            List<ProfileCustomMetadataTypeAccesses> newCustomMetadataTypeAccesses = new List<ProfileCustomMetadataTypeAccesses>();
            List<ProfileCustomPermissions> newProfileCustomPermissions = new List<ProfileCustomPermissions>();
            List<ProfilePageAccesses> newProfilePageAccesses = new List<ProfilePageAccesses>();
            List<ProfileApplicationVisibilities> newProfileApplicationVisibilities = new List<ProfileApplicationVisibilities>();
            List<ProfileUserPermissions> newProfileUserPermissions = new List<ProfileUserPermissions>();

            if (profile.classAccesses != null)
            {
                foreach (var item in profile.classAccesses)
                {
                    Boolean commonElement = commonElementProfile.Exists(item);

                    if (!commonElement)
                    {
                        newClassAccesses.Add(item);
                    }
                }
            }

            if (profile.fieldPermissions != null)
            {
                foreach (var item in profile.fieldPermissions)
                {
                    Boolean commonElement = commonElementProfile.Exists(item); 

                    if (!commonElement)
                    {
                        newFieldPermissions.Add(item);
                    }
                }
            }

            if (profile.layoutAssignments != null)
            {
                foreach (var item in profile.layoutAssignments)
                {
                    Boolean commonElement = commonElementProfile.Exists(item);

                    if (!commonElement)
                    {
                        newLayoutAssignments.Add(item);
                    }
                }
            }

            if (profile.recordTypeVisibilities != null)
            {
                foreach (var item in profile.recordTypeVisibilities)
                {
                    Boolean commonElement = commonElementProfile.Exists(item); 

                    if (!commonElement)
                    {
                        newRecordTypeVisibilities.Add(item);
                    }
                }
            }

            if (profile.tabVisibilities != null)
            {
                foreach (var item in profile.tabVisibilities)
                {
                    Boolean commonElement = commonElementProfile.Exists(item); 

                    if (!commonElement)
                    {
                        newTabVisibilities.Add(item);
                    }
                }
            }

            if (profile.objectPermissions != null)
            {
                foreach (var item in profile.objectPermissions)
                {
                    Boolean commonElement = commonElementProfile.Exists(item); 

                    if (!commonElement)
                    {
                        newObjectPermissions.Add(item);
                    }
                }
            }

            if (profile.customMetadataTypeAccesses != null)
            {
                foreach (var item in profile.customMetadataTypeAccesses)
                {
                    Boolean commonElement = commonElementProfile.Exists(item);  

                    if (!commonElement)
                    {
                        newCustomMetadataTypeAccesses.Add(item);
                    }
                }
            }

            if (profile.customPermissions != null)
            {
                foreach (var item in profile.customPermissions)
                {
                    Boolean commonElement = commonElementProfile.Exists(item); 

                    if (!commonElement)
                    {
                        newProfileCustomPermissions.Add(item);
                    }
                }
            }

            if (profile.pageAccesses != null)
            {
                foreach (var item in profile.pageAccesses)
                {
                    Boolean commonElement = commonElementProfile.Exists(item);  

                    if (!commonElement)
                    {
                        newProfilePageAccesses.Add(item);
                    }
                }
            }

            if (profile.applicationVisibilities != null)
            {
                foreach (var item in profile.applicationVisibilities)
                {
                    Boolean commonElement = commonElementProfile.Exists(item);  

                    if (!commonElement)
                    {
                        newProfileApplicationVisibilities.Add(item);
                    }
                }
            }

            if (profile.userPermissions != null)
            {
                foreach (var item in profile.userPermissions)
                {
                    Boolean commonElement = commonElementProfile.Exists(item);  

                    if (!commonElement)
                    {
                        newProfileUserPermissions.Add(item);
                    }
                }
            }

            profile.classAccesses = newClassAccesses.ToArray();
            profile.fieldPermissions = newFieldPermissions.ToArray();
            profile.layoutAssignments = newLayoutAssignments.ToArray();
            profile.recordTypeVisibilities = newRecordTypeVisibilities.ToArray();
            profile.tabVisibilities = newTabVisibilities.ToArray();
            profile.objectPermissions = newObjectPermissions.ToArray();
            profile.customPermissions = newProfileCustomPermissions.ToArray();
            profile.customMetadataTypeAccesses = newCustomMetadataTypeAccesses.ToArray();
            profile.pageAccesses = newProfilePageAccesses.ToArray();
            profile.applicationVisibilities = newProfileApplicationVisibilities.ToArray();
            profile.userPermissions = newProfileUserPermissions.ToArray();

            return profile;

        }

    }
}
