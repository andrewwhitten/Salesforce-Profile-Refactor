using System;

/// <summary>
/// Extension to the auto-generated Profile section classes in Sample.cs
/// The only purpose of these partial classes is to allow the various arrays properties in the Profile class to be sorted
/// alphabetically. This is not needed by Salesforce as such, but will make it easier to find your elements when searching manually
/// </summary>
namespace SalesforceProfileRefactor
{
    /// <summary>
    /// Extension to the auto-generated ProfileApplicationVisibilities class in Sample.cs
    /// </summary>
    public partial class ProfileApplicationVisibilities : IComparable<ProfileApplicationVisibilities>
    {
        public int CompareTo(ProfileApplicationVisibilities profileApplicationVisibilities)
        {
            if (profileApplicationVisibilities is null)
            {
                // If other is not a valid object reference, this instance is greater.
                return 1;
            }

            var en = new System.Globalization.CultureInfo("en-US");

            int compareProperty = String.Compare(this.application, profileApplicationVisibilities.application, en, System.Globalization.CompareOptions.None);

            return compareProperty;
        }

    }

    /// <summary>
    /// Extension to the auto-generated ProfileClassAccesses class in Sample.cs
    /// </summary>
    public partial class ProfileClassAccesses : IComparable<ProfileClassAccesses>
    {
        public int CompareTo(ProfileClassAccesses profileClassAccesses)
        {
            if (profileClassAccesses is null)
            {
                // If other is not a valid object reference, this instance is greater.
                return 1;
            }

            var en = new System.Globalization.CultureInfo("en-US");

            int compareProperty = String.Compare(this.apexClass, profileClassAccesses.apexClass, en, System.Globalization.CompareOptions.None);

            return compareProperty;
        }

    }

    /// <summary>
    /// Extension to the auto-generated ProfileCustomMetadataTypeAccesses class in Sample.cs
    /// </summary>
    public partial class ProfileCustomMetadataTypeAccesses : IComparable<ProfileCustomMetadataTypeAccesses>
    {
        public int CompareTo(ProfileCustomMetadataTypeAccesses profileCustomMetadataTypeAccesses)
        {
            if (profileCustomMetadataTypeAccesses is null)
            {
                // If other is not a valid object reference, this instance is greater.
                return 1;
            }

            var en = new System.Globalization.CultureInfo("en-US");

            int compareProperty = String.Compare(this.name, profileCustomMetadataTypeAccesses.name, en, System.Globalization.CompareOptions.None);

            return compareProperty;
        }

    }

    /// <summary>
    /// Extension to the auto-generated ProfileCustomPermissions class in Sample.cs
    /// </summary>
    public partial class ProfileCustomPermissions : IComparable<ProfileCustomPermissions>
    {
        public int CompareTo(ProfileCustomPermissions profileCustomPermissions)
        {
            if (profileCustomPermissions is null)
            {
                // If other is not a valid object reference, this instance is greater.
                return 1;
            }

            var en = new System.Globalization.CultureInfo("en-US");

            int compareProperty = String.Compare(this.name, profileCustomPermissions.name, en, System.Globalization.CompareOptions.None);

            return compareProperty;
        }

    }

    /// <summary>
    /// Extension to the auto-generated ProfileFieldPermissions class in Sample.cs
    /// </summary>
    public partial class ProfileFieldPermissions : IComparable<ProfileFieldPermissions>
    {
        public int CompareTo(ProfileFieldPermissions profileFieldPermissions)
        {
            if (profileFieldPermissions is null)
            {
                // If other is not a valid object reference, this instance is greater.
                return 1;
            }

            var en = new System.Globalization.CultureInfo("en-US");

            int compareProperty = String.Compare(this.field, profileFieldPermissions.field, en, System.Globalization.CompareOptions.None);

            return compareProperty;
        }

    }

    /// <summary>
    /// Extension to the auto-generated ProfileLayoutAssignments class in Sample.cs
    /// </summary>
    public partial class ProfileLayoutAssignments : IComparable<ProfileLayoutAssignments>
    {
        public int CompareTo(ProfileLayoutAssignments profileLayoutAssignments)
        {
            if (profileLayoutAssignments is null)
            {
                // If other is not a valid object reference, this instance is greater.
                return 1;
            }

            var en = new System.Globalization.CultureInfo("en-US");

            int compareProperty = String.Compare(this.layout, profileLayoutAssignments.layout, en, System.Globalization.CompareOptions.None);

            return compareProperty;
        }

    }

    /// <summary>
    /// Extension to the auto-generated ProfileLoginIpRanges class in Sample.cs - not used in PermSets
    /// </summary>
    public partial class ProfileLoginIpRanges : IComparable<ProfileLoginIpRanges>
    {
        public int CompareTo(ProfileLoginIpRanges profileLoginIpRanges)
        {
            if (profileLoginIpRanges is null)
            {
                // If other is not a valid object reference, this instance is greater.
                return 1;
            }

            var en = new System.Globalization.CultureInfo("en-US");

            int compareProperty = String.Compare(this.startAddress, profileLoginIpRanges.startAddress, en, System.Globalization.CompareOptions.None);

            return compareProperty;
        }

    }

    /// <summary>
    /// Extension to the auto-generated ProfileObjectPermissions class in Sample.cs
    /// </summary>
    public partial class ProfileObjectPermissions : IComparable<ProfileObjectPermissions>
    {
        public int CompareTo(ProfileObjectPermissions profileObjectPermissions)
        {
            if (profileObjectPermissions is null)
            {
                // If other is not a valid object reference, this instance is greater.
                return 1;
            }

            var en = new System.Globalization.CultureInfo("en-US");

            int compareProperty = String.Compare(this.@object, profileObjectPermissions.@object, en, System.Globalization.CompareOptions.None);

            return compareProperty;
        }

    }

    /// <summary>
    /// Extension to the auto-generated ProfilePageAccesses class in Sample.cs
    /// </summary>
    public partial class ProfilePageAccesses : IComparable<ProfilePageAccesses>
    {
        public int CompareTo(ProfilePageAccesses profilePageAccesses)
        {
            if (profilePageAccesses is null)
            {
                // If other is not a valid object reference, this instance is greater.
                return 1;
            }

            var en = new System.Globalization.CultureInfo("en-US");

            int compareProperty = String.Compare(this.apexPage, profilePageAccesses.apexPage, en, System.Globalization.CompareOptions.None);

            return compareProperty;
        }

    }

    /// <summary>
    /// Extension to the auto-generated ProfileTabVisibilities class in Sample.cs
    /// </summary>
    /// <remarks>
    /// Permission sets have these as license dependant https://help.salesforce.com/articleView?id=000333496&type=1&mode=1
    /// </remarks>
    public partial class ProfileTabVisibilities : IComparable<ProfileTabVisibilities>
    {
        public int CompareTo(ProfileTabVisibilities profileTabVisibilities)
        {
            if (profileTabVisibilities is null)
            {
                // If other is not a valid object reference, this instance is greater.
                return 1;
            }

            var en = new System.Globalization.CultureInfo("en-US");

            int compareProperty = String.Compare(this.tab, profileTabVisibilities.tab, en, System.Globalization.CompareOptions.None);

            return compareProperty;
        }

    }

    /// <summary>
    /// Extension to the auto-generated ProfileRecordTypeVisibilities class in Sample.cs
    /// </summary>
    /// <remarks>
    /// Permission sets cannot specify master record tpyes https://help.salesforce.com/articleView?id=permissions_record_type_access.htm&type=5
    /// </remarks>
    public partial class ProfileRecordTypeVisibilities : IComparable<ProfileRecordTypeVisibilities>
    {
        public int CompareTo(ProfileRecordTypeVisibilities profileRecordTypeVisibilities)
        {
            if (profileRecordTypeVisibilities is null)
            {
                // If other is not a valid object reference, this instance is greater.
                return 1;
            }

            var en = new System.Globalization.CultureInfo("en-US");

            int compareProperty = String.Compare(this.recordType, profileRecordTypeVisibilities.recordType, en, System.Globalization.CompareOptions.None);

            return compareProperty;
        }

    }

    /// <summary>
    /// Extension to the auto-generated ProfileUserPermissions class in Sample.cs
    /// </summary>
    public partial class ProfileUserPermissions : IComparable<ProfileUserPermissions>
    {
        public int CompareTo(ProfileUserPermissions profileUserPermissions)
        {
            if (profileUserPermissions is null)
            {
                // If other is not a valid object reference, this instance is greater.
                return 1;
            }

            var en = new System.Globalization.CultureInfo("en-US");

            int compareProperty = String.Compare(this.name, profileUserPermissions.name, en, System.Globalization.CompareOptions.None);

            return compareProperty;
        }

    }
}
