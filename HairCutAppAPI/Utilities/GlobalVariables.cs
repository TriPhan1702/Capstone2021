using System.Collections.Generic;

namespace HairCutAppAPI.Utilities
{
    //Store Variables used throughout the app
    public static class GlobalVariables
    {
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

        public static readonly string[] StaffTypes = {"Stylist", "Beautician", "Receptionist"};
    }
}