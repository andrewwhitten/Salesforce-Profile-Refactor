using System;

namespace SalesforceProfileRefactor
{
    /// <summary>
    /// Helper methods to extend the auto-generated Profile class. These determine
    /// if a property value in another profile exists in this Profile
    /// </summary>
    public partial class Profile 
    {
        /// <summary>
        /// Check if this Profile contains at least one instance of ProfileApplicationVisibilities
        /// </summary>
        /// <param name="profileApplicationVisibilities"></param>
        /// <returns></returns>
        public bool Exists(ProfileApplicationVisibilities profileApplicationVisibilities)
        {
            if (this.applicationVisibilities == null)
            {
                return false;  // No it doesn't exist
            }

            bool match = false;

            foreach (var item in this.applicationVisibilities)
            {
                if (item.application.Equals(profileApplicationVisibilities.application))
                {
                    match = (item.visible == profileApplicationVisibilities.visible) ? true : false;
                }

                if (match)
                {
                    break;
                }

            }

            return match;
        }

        /// <summary>
        /// Check if this Profile contains at least one instance of ProfileClassAccesses
        /// </summary>
        /// <param name="profileClassAccesses"></param>
        /// <returns></returns>
        public bool Exists(ProfileClassAccesses profileClassAccesses)
        {
            if (this.classAccesses == null)
            {
                return false;  // No it doesn't exist
            }

            bool match = false;

            foreach (var item in this.classAccesses)
            {
                match = (item.apexClass == profileClassAccesses.apexClass) ? true : false;

                if (match) { match = (item.enabled == profileClassAccesses.enabled) ? true : false; }

                if (match)
                {
                    break;
                }
            }

            return match;
        }

        /// <summary>
        /// Check if this Profile contains at least one instance of ProfileCustomMetadataTypeAccesses
        /// </summary>
        /// <param name="profileCustomMetadataTypeAccesses"></param>
        /// <returns></returns>
        public bool Exists(ProfileCustomMetadataTypeAccesses profileCustomMetadataTypeAccesses)
        {
            if (this.customMetadataTypeAccesses == null)
            {
                return false;  // No it doesn't exist
            }

            bool match = false;

            foreach (var item in this.customMetadataTypeAccesses)
            {
                if (item.name.Equals(profileCustomMetadataTypeAccesses.name))
                {
                    match = (item.enabled == profileCustomMetadataTypeAccesses.enabled) ? true : false;
                }

                if (match)
                {
                    break; // Found match, don't look further
                }

            }

            return match;
        }

        /// <summary>
        /// Check if this Profile contains at least one instance of ProfileCustomPermissions
        /// </summary>
        /// <param name="profileCustomPermissions"></param>
        /// <returns></returns>
        public bool Exists(ProfileCustomPermissions profileCustomPermissions)
        {
            if (this.customPermissions == null)
            {
                return false;  // No it doesn't exist
            }

            bool match = false;

            foreach (var item in this.customPermissions)
            {
                if (item.name.Equals(profileCustomPermissions.name))
                {
                    match = (item.enabled == profileCustomPermissions.enabled) ? true : false;
                }

                if (match)
                {
                    break; // Found match, don't look further
                }

            }

            return match;
        }

        /// <summary>
        /// Check if this Profile contains at least one instance of ProfileFieldPermissions
        /// </summary>
        /// <param name="profileFieldPermissions"></param>
        /// <returns></returns>
        public bool Exists(ProfileFieldPermissions profileFieldPermissions)
        {
            if (this.fieldPermissions == null)
            {
                return false;  // No it doesn't exist
            }

            bool match = false;

            foreach (var item in this.fieldPermissions)
            {
                match = (item.field == profileFieldPermissions.field) ? true : false;

                if (match) { match = (item.editable == profileFieldPermissions.editable) ? true : false; }

                if (match) { match = (item.readable == profileFieldPermissions.readable) ? true : false; }

                if (match)
                {
                    break; // Found match, don't look further
                }
            }

            return match;
        }

        /// <summary>
        /// Check if this Profile contains at least one instance of ProfileLayoutAssignments
        /// </summary>
        /// <param name="profileLayoutAssignments"></param>
        /// <returns></returns>
        public bool Exists(ProfileLayoutAssignments profileLayoutAssignments)
        {
            if (this.layoutAssignments == null)
            {
                return false;  // No it doesn't exist
            }

            bool match = false;

            foreach (var item in this.layoutAssignments)
            {
                if (item.layout.Equals(profileLayoutAssignments.layout))
                {

                    if (item.recordType == null && profileLayoutAssignments.recordType == null)
                    {
                        match = true;
                    }
                    else if (item.recordType == null || profileLayoutAssignments.recordType == null)
                    {
                        match = false;
                    }
                    else if (item.recordType.Equals(profileLayoutAssignments.recordType))
                    {
                        match = true;
                    }
                }

                if (match)
                {
                    break;
                }
            }

            return match;
        }

        /// <summary>
        /// Check if this Profile contains at least one instance of ProfileObjectPermissions
        /// </summary>
        /// <param name="profileObjectPermissions"></param>
        /// <returns></returns>
        public bool Exists(ProfileObjectPermissions profileObjectPermissions)
        {
            if (this.objectPermissions == null)
            {
                return false;  // No it doesn't exist
            }

            bool match = false;

            foreach (var item in this.objectPermissions)
            {
                if (item.@object.Equals(profileObjectPermissions.@object))
                {
                    match = (item.allowCreate == profileObjectPermissions.allowCreate) ? true : false;

                    if (match) { match = (item.allowDelete == profileObjectPermissions.allowDelete) ? true : false; }

                    if (match) { match = (item.allowEdit == profileObjectPermissions.allowEdit) ? true : false; }

                    if (match) { match = (item.allowRead == profileObjectPermissions.allowRead) ? true : false; }

                    if (match) { match = (item.modifyAllRecords == profileObjectPermissions.modifyAllRecords) ? true : false; }

                    if (match) { match = (item.viewAllRecords == profileObjectPermissions.viewAllRecords) ? true : false; }
                }

                if (match)
                {
                    break;
                }
            }

            return match;
        }

        /// <summary>
        /// Check if this Profile contains at least one instance of ProfilePageAccesses
        /// </summary>
        /// <param name="profilePageAccesses"></param>
        /// <returns></returns>
        public bool Exists(ProfilePageAccesses profilePageAccesses)
        {
            if (this.pageAccesses == null)
            {
                return false;  // No it doesn't exist
            }

            bool match = false;

            foreach (var item in this.pageAccesses)
            {
                if (item.apexPage.Equals(profilePageAccesses.apexPage))
                {
                    match = (item.enabled == profilePageAccesses.enabled) ? true : false;
                }

                if (match)
                {
                    break;
                }

            }

            return match;
        }

        /// <summary>
        /// Check if this Profile contains at least one instance of ProfileRecordTypeVisibilities
        /// </summary>
        /// <param name="profileRecordTypeVisibilities"></param>
        /// <returns></returns>
        public bool Exists(ProfileRecordTypeVisibilities profileRecordTypeVisibilities)
        {
            if (this.recordTypeVisibilities == null)
            {
                return false;  // No it doesn't exist
            }

            bool match = false;

            foreach (var item in this.recordTypeVisibilities)
            {
                if (item.recordType.Equals(profileRecordTypeVisibilities.recordType))
                {
                    match = (item.personAccountDefault == profileRecordTypeVisibilities.personAccountDefault) ? true : false;

                    if (match) { match = (item.personAccountDefaultSpecified == profileRecordTypeVisibilities.personAccountDefaultSpecified) ? true : false; };

                    if (match) { match = (item.visible == profileRecordTypeVisibilities.visible) ? true : false; };

                    if (match) { match = (item.@default == profileRecordTypeVisibilities.@default) ? true : false; };
                }

                if (match)
                {
                    break;
                }
            }

            return match;
        }

        /// <summary>
        /// Check if this Profile contains at least one instance of ProfileTabVisibilities
        /// </summary>
        /// <param name="profileTabVisibilities"></param>
        /// <returns></returns>
        public bool Exists(ProfileTabVisibilities profileTabVisibilities)
        {
            if (this.tabVisibilities == null)
            {
                return false;  // No it doesn't exist
            }

            bool match = false;

            foreach (var item in this.tabVisibilities)
            {
                if (item.tab.Equals(profileTabVisibilities.tab))
                {
                    match = (item.visibility == profileTabVisibilities.visibility) ? true : false;
                }

                if (match)
                {
                    break;
                }
            }

            return match;
        }

        /// <summary>
        /// Check if this Profile contains at least one instance of ProfileUserPermissions
        /// </summary>
        /// <param name="profileUserPermissions"></param>
        /// <returns></returns>
        public bool Exists(ProfileUserPermissions profileUserPermissions)
        {

            if (this.userPermissions == null)
            {
                return false;  // No it doesn't exist
            }

            bool match = false;

            foreach (var item in this.userPermissions)
            {
                if (item.name.Equals(profileUserPermissions.name))
                {
                    match = (item.enabled == profileUserPermissions.enabled) ? true : false;
                }

                if (match)
                {
                    break;
                }
            }

            return match;
        }
    }
}
