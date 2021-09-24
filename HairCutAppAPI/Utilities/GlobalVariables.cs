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
        public const string StaffRole = "Staff";
        public const string CustomerRole = "Customer";
        
        //Names of authorization policies
        public const string RequireAdministratorRole = "RequireAdministratorRole";
        public const string RequireCustomerRole = "RequireCustomerRole";
        public const string RequireManagerRole = "RequireManagerRole";
        public const string RequireStaffRole = "RequireStaffRole";
    }
}