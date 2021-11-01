using System.Collections.Generic;
using System.Globalization;

namespace HairCutAppAPI.Utilities
{
    //Store Variables used throughout the app
    public static class GlobalVariables
    {
        //Regex
        public const string DateRegex = @"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$";
        public const string EmailRegex = @"^[a-z0-9](\.?[a-z0-9]){5,}@g(oogle)?mail\.com$";
        public const string PhoneNumberRegex = @"^(?:[0-9]{10})$";
        
        //Messages
        public const string DateRegexMessage = "dd/MM/yyyy";
        
        //Social Login Platforms
        public const string Google = "google";
        public const string Facebook = "facebook";
        public const string Apple = "apple";
        
        //Date Formats
        public const int TimeZone = 7;
        public const string DateTimeFormat = "dd/MM/yyyy HH:mm:ss";
        public const string DayFormat = "dd/MM/yyyy";
        public const string TimeFormat = @"hh\:mm";
        
        //Time variables
        public const int TimeToCreateAppointmentInAdvanced = 120;
        public const int TimeToConfirmAppointmentInAdvanced = 60;
        
        //Name of roles
        public const string AdministratorRole = "administrator";
        public const string ManagerRole = "manager";
        public const string StylistRole = "stylist";
        public const string BeauticianRole = "beautician";
        public const string CustomerRole = "customer";
        public static readonly string[] Roles = {AdministratorRole, ManagerRole, StylistRole,BeauticianRole,CustomerRole};
        public static readonly string[] UserRolesWithoutSeparateTable = {AdministratorRole};
        
        //Names of authorization policies
        public const string RequireAdministratorRole = "RequireAdministratorRole";
        public const string RequireCustomerRole = "RequireCustomerRole";
        public const string RequireManagerRole = "RequireManagerRole";
        public const string RequireStylistRole = "RequireStylistRole";
        public const string RequireBeauticianRole = "RequireBeauticianRole";

        //Status Lists
        public static readonly string[] UserStatuses = {"active", "inactive", "new"};
        public static readonly string[] StaffTypes = {"stylist", "beautician", "manager"};
        public static readonly string[] ServiceStatuses = {"active", "inactive"};
        public static readonly string[] ComboStatuses = {"active", "inactive"};
        public static readonly string[] DeviceStatuses = {"active", "inactive"};
        public static readonly string[] SalonStatuses = {"active", "inactive"};
        public static readonly string[] AppointmentStatuses = {"pending","approved","ongoing","canceled","completed"};
        public static readonly string[] ActiveAppointmentStatuses = {"pending","approved","ongoing"};
        public static readonly string[] WorkSlotStatuses = {"available","not available","taken"};
        public static readonly string[] PromotionalCodeStatuses = {"active", "inactive", "canceled"};
        public static readonly string[] ArticleStatuses = {"active", "inactive"};
        
        //The Default Status a new entity will get
        public const string NewUserStatus = "active";
        public const string NewAppointmentStatus = "pending";
        public const string PendingAppointmentStatus = "pending";
        public const string ApprovedAppointmentStatus = "approved";
        public const string CompleteAppointmentStatus = "completed";
        public const string CanceledAppointmentStatus = "canceled";
        public const string TakenAppointmentStatus = "taken";
        public const string NewSalonStatus = "active";
        public const string AvailableWorkSlotStatus = "available";
        public const string NotAvailableWorkSlotStatus = "not available";
        public const string NewPromotionalCodeStatus = ActivePromotionalCodeStatus;
        public const string ActivePromotionalCodeStatus = "active";
        public const string ActiveComboStatus = "active";
        public const string ActiveUserStatus = "active";
        public const string ActiveSalonStatus = "active";
        public const string InActiveUserStatus = "inactive";
        public const string InActiveSalonStatus = "inactive";
        public const string NewArticleStatus = "active";
        public const string ActiveArticleStatus = "active";
        public const string InActiveArticleStatus = "inactive";
    }
}