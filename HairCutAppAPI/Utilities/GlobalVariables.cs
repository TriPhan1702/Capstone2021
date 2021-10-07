using System.Collections.Generic;

namespace HairCutAppAPI.Utilities
{
    //Store Variables used throughout the app
    public static class GlobalVariables
    {
        //Social Login Platforms
        public const string Google = "google";
        public const string Facebook = "facebook";
        public const string Apple = "apple";
        
        //Date Formats
        public const int TimeZone = 7;
        public const string DateTimeResponseFormat = "dd/MM/yyyy HH:mm:ss";
        public const string BirthDayFormat = "dd/MM/yyyy";
        
        //Name of roles
        public const string AdministratorRole = "Administrator";
        public const string ManagerRole = "Manager";
        public const string StylistRole = "Stylist";
        public const string BeauticianRole = "Beautician";
        public const string CustomerRole = "Customer";
        
        //Names of authorization policies
        public const string RequireAdministratorRole = "RequireAdministratorRole";
        public const string RequireCustomerRole = "RequireCustomerRole";
        public const string RequireManagerRole = "RequireManagerRole";
        public const string RequireStylistRole = "RequireStylistRole";
        public const string RequireBeauticianRole = "RequireBeauticianRole";

        //Status Lists
        public static readonly string[] StaffTypes = {"Stylist", "Beautician", "Receptionist"};
        public static readonly string[] ServiceStatuses = {"active", "inactive"};
        public static readonly string[] ComboStatuses = {"active", "inactive"};
        public static readonly string[] DeviceStatuses = {"active", "inactive"};
        public static readonly string[] SalonStatuses = {"active", "inactive"};
        public static readonly string[] NotificationStatuses = {"pending","active","canceled","completed"};
        public static readonly string[] WorkSlotStatuses = {"available","not available","taken","pending"};
    }
}