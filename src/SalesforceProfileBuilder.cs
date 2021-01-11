using System;
using System.Collections.Generic;

namespace SalesforceProfileRefactor
{
    /// <summary>
    /// 
    /// </summary>
    public class SalesforceProfileBuilder
    {
        /// <summary>
        /// Create a new Profile from the common subset of multiple other Profiles
        /// </summary>
        /// <param name="origionalProfile"></param>
        /// <param name="comparisionProfiles"></param>
        /// <returns>A Profile with common subset defined</returns>
        static public Profile ProfileWithCommonElements(Profile origionalProfile, Dictionary<String, Profile> comparisionProfiles)
        {
            Profile commonElementProfile = new Profile();

            // Identify common Class Accesses
            if (origionalProfile.classAccesses != null)
            {
                List<ProfileClassAccesses> subsetProfileClassAccesses = new List<ProfileClassAccesses>();

                foreach (var item in origionalProfile.classAccesses)
                {
                    Boolean commonElement = SalesforceProfileCompareUtilty.DoesItemExistInComparisonProfiles(comparisionProfiles, item);

                    if (commonElement)
                    {
                        subsetProfileClassAccesses.Add(item);
                    }
                }

                //subsetProfileClassAccesses.Sort();

                commonElementProfile.classAccesses = subsetProfileClassAccesses.ToArray();
            }

            // Identify common Field Permissions
            if (origionalProfile.fieldPermissions != null)
            {
                List<ProfileFieldPermissions> subsetProfileFieldPermissions = new List<ProfileFieldPermissions>();

                foreach (var item in origionalProfile.fieldPermissions)
                {
                    Boolean commonElement = SalesforceProfileCompareUtilty.DoesItemExistInComparisonProfiles(comparisionProfiles, item);

                    if (commonElement)
                    {
                        subsetProfileFieldPermissions.Add(item);
                    }
                }

                //subsetProfileFieldPermissions.Sort();

                commonElementProfile.fieldPermissions = subsetProfileFieldPermissions.ToArray();
            }


            if (origionalProfile.layoutAssignments != null)
            {
                // Identify common Layout Assignments
                List<ProfileLayoutAssignments> subsetProfileLayoutAssignments = new List<ProfileLayoutAssignments>();

                foreach (var item in origionalProfile.layoutAssignments)
                {
                    Boolean commonElement = SalesforceProfileCompareUtilty.DoesItemExistInComparisonProfiles(comparisionProfiles, item);

                    if (commonElement)
                    {
                        subsetProfileLayoutAssignments.Add(item);
                    }
                }

                commonElementProfile.layoutAssignments = subsetProfileLayoutAssignments.ToArray();
            }


            if (origionalProfile.recordTypeVisibilities != null)
            {
                // Identify common Layout Assignments
                List<ProfileRecordTypeVisibilities> subsetProfileRecordTypeVisibilities = new List<ProfileRecordTypeVisibilities>();

                foreach (var item in origionalProfile.recordTypeVisibilities)
                {
                    Boolean commonElement = SalesforceProfileCompareUtilty.DoesItemExistInComparisonProfiles(comparisionProfiles, item);

                    if (commonElement)
                    {
                        subsetProfileRecordTypeVisibilities.Add(item);
                    }
                }

                commonElementProfile.recordTypeVisibilities = subsetProfileRecordTypeVisibilities.ToArray();
            }


            if (origionalProfile.tabVisibilities != null)
            {
                // Tab Visibilities
                List<ProfileTabVisibilities> subsetProfileTabVisibilities = new List<ProfileTabVisibilities>();

                foreach (var item in origionalProfile.tabVisibilities)
                {
                    Boolean commonElement = SalesforceProfileCompareUtilty.DoesItemExistInComparisonProfiles(comparisionProfiles, item);

                    if (commonElement)
                    {
                        subsetProfileTabVisibilities.Add(item);
                    }
                }

                commonElementProfile.tabVisibilities = subsetProfileTabVisibilities.ToArray();
            }


            if (origionalProfile.objectPermissions != null)
            {
                // Object Permissions
                List<ProfileObjectPermissions> subsetProfileObjectPermissions = new List<ProfileObjectPermissions>();

                foreach (var item in origionalProfile.objectPermissions)
                {
                    Boolean commonElement = SalesforceProfileCompareUtilty.DoesItemExistInComparisonProfiles(comparisionProfiles, item);

                    if (commonElement)
                    {
                        subsetProfileObjectPermissions.Add(item);
                    }
                }

                commonElementProfile.objectPermissions = subsetProfileObjectPermissions.ToArray();
            }

            if (origionalProfile.customMetadataTypeAccesses != null)
            {
                // Custom MetaData Permissions
                List<ProfileCustomMetadataTypeAccesses> subsetProfileCustomMetadataTypeAccesses = new List<ProfileCustomMetadataTypeAccesses>();

                foreach (var item in origionalProfile.customMetadataTypeAccesses)
                {
                    Boolean commonElement = SalesforceProfileCompareUtilty.DoesItemExistInComparisonProfiles(comparisionProfiles, item);

                    if (commonElement)
                    {
                        subsetProfileCustomMetadataTypeAccesses.Add(item);
                    }
                }

                commonElementProfile.customMetadataTypeAccesses = subsetProfileCustomMetadataTypeAccesses.ToArray();
            }


            if (origionalProfile.customPermissions != null)
            {
                // Custom Permissions
                List<ProfileCustomPermissions> subSetProfileCustomPermissions = new List<ProfileCustomPermissions>();

                foreach (var item in origionalProfile.customPermissions)
                {
                    Boolean commonElement = SalesforceProfileCompareUtilty.DoesItemExistInComparisonProfiles(comparisionProfiles, item);

                    if (commonElement)
                    {
                        subSetProfileCustomPermissions.Add(item);
                    }
                }

                commonElementProfile.customPermissions = subSetProfileCustomPermissions.ToArray();
            }


            if (origionalProfile.pageAccesses != null)
            {
                // Page Accesses
                List<ProfilePageAccesses> subSetPageAccesses = new List<ProfilePageAccesses>();

                foreach (var item in origionalProfile.pageAccesses)
                {
                    Boolean commonElement = SalesforceProfileCompareUtilty.DoesItemExistInComparisonProfiles(comparisionProfiles, item);

                    if (commonElement)
                    {
                        subSetPageAccesses.Add(item);
                    }
                }

                commonElementProfile.pageAccesses = subSetPageAccesses.ToArray();
            }


            if (origionalProfile.applicationVisibilities != null)
            {
                // Application visibilities
                List<ProfileApplicationVisibilities> subsetApplicationVisibilities = new List<ProfileApplicationVisibilities>();

                foreach (var item in origionalProfile.applicationVisibilities)
                {
                    Boolean commonElement = SalesforceProfileCompareUtilty.DoesItemExistInComparisonProfile(comparisionProfiles, item);

                    if (commonElement)
                    {
                        subsetApplicationVisibilities.Add(item);
                    }
                }

                commonElementProfile.applicationVisibilities = subsetApplicationVisibilities.ToArray();
            }


            if (origionalProfile.userPermissions != null)
            {
                // User Permissions
                List<ProfileUserPermissions> profileUserPermissions = new List<ProfileUserPermissions>();

                foreach (var item in origionalProfile.userPermissions)
                {
                    Boolean commonElement = SalesforceProfileCompareUtilty.DoesItemExistInComparisonProfiles(comparisionProfiles, item);

                    if (commonElement)
                    {
                        profileUserPermissions.Add(item);
                    }
                }

                commonElementProfile.userPermissions = profileUserPermissions.ToArray();

            }

            return commonElementProfile;
        }

    }
}
