using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities.Payment;
using HairCutAppAPI.Utilities.Violation;

namespace HairCutAppAPI.Utilities
{
    //Store Variables used throughout the app
    public static class GlobalVariables
    {
        //Regex
        public const string DateRegex = @"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$";
        public const string EmailRegex = @"^[a-z0-9](\.?[a-z0-9]){5,}@g(oogle)?mail\.com$";
        public const string PhoneNumberRegex = @"^(?:[0-9]{10})$";
        
        //Payment Types
        public static ReadOnlyCollection<PaymentType> PaymentTypes { get; } = new ReadOnlyCollection<PaymentType>(
            new PaymentType[] { 
                new PaymentType(){Id = 1, Name = "Trả trực tiếp"}, 
            }
        );
        
        //Messages
        public const string DateRegexMessage = "dd/MM/yyyy";
        public const string PhoneNumberRegexMessage = "Phone Number is Invalid";
        
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
        public const int TimeToFinishAppointmentInAdvanced = 300;
        
        //Name of roles
        public const string AdministratorRole = "administrator";
        public const string ManagerRole = "manager";
        public const string StylistRole = "stylist";
        public const string BeauticianRole = "beautician";
        public const string CustomerRole = "customer";
        public static readonly string[] Roles = {AdministratorRole, ManagerRole, StylistRole,BeauticianRole,CustomerRole};
        public static readonly string[] UserRolesWithoutSeparateTable = {AdministratorRole};
        public static readonly string[] AppointmentPerformingRoles = {StylistRole, BeauticianRole};

        //Statuses
        public const string ActiveUserStatus = "active";
        public const string InActiveUserStatus = "inactive";
        public const string NewUserStatus = ActiveUserStatus;
        
        public const string PendingAppointmentStatus = "pending";
        public const string ApprovedAppointmentStatus = "approved";
        public const string CompleteAppointmentStatus = "completed";
        public const string CanceledAppointmentStatus = "canceled";
        public const string OnGoingAppointmentStatus = "ongoing";
        public const string NewAppointmentStatus = PendingAppointmentStatus;
        
        public const string AvailableWorkSlotStatus = "available";
        public const string NotAvailableWorkSlotStatus = "not available";
        public const string TakenWorkSlotStatus = "taken";
        
        public const string ActivePromotionalCodeStatus = "active";
        public const string InActivePromotionalCodeStatus = "inactive";
        public const string CanceledPromotionalCodeStatus = "canceled";
        public const string NewPromotionalCodeStatus = ActivePromotionalCodeStatus;
        
        public const string ActiveComboStatus = "active";
        public const string InActiveComboStatus = "inactive";
        
        public const string ActiveServiceStatus = "active";
        public const string InActiveServiceStatus = "inactive";
        
        public const string ActiveDeviceStatus = "active";
        public const string InActiveDeviceStatus = "inactive";
        
        public const string ActiveSalonStatus = "active";
        public const string NewSalonStatus = ActiveSalonStatus;
        public const string InActiveSalonStatus = "inactive";
        
        public const string ActiveArticleStatus = "active";
        public const string InActiveArticleStatus = "inactive";
        public const string NewArticleStatus = ActiveArticleStatus;
        
        public const string PendingNotificationStatus = "pending";
        public const string DeliveredNotificationStatus = "delivered";
        public const string SeenNotificationStatus = "seen";
        public const string CanceledNotificationStatus = "canceled";
        
        public const string AppointmentCreatedNotification = "appointment_created";
        public const string AppointmentApprovedNotification = "appointment_approved";
        public const string AppointmentCanceledNotification = "appointment_canceled";
        public const string AppointmentCompleteNotification = "appointment_complete";
        
        //Status Lists
        public static readonly string[] UserStatuses = {ActiveUserStatus, InActiveUserStatus};
        public static readonly string[] StaffTypes = {StylistRole, BeauticianRole, ManagerRole};
        public static readonly string[] ServiceStatuses = {ActiveServiceStatus, InActiveServiceStatus};
        public static readonly string[] ComboStatuses = {ActiveComboStatus, InActiveComboStatus};
        public static readonly string[] DeviceStatuses = {ActiveDeviceStatus, InActiveDeviceStatus};
        public static readonly string[] SalonStatuses = {ActiveSalonStatus, InActiveSalonStatus};
        public static readonly string[] AppointmentStatuses = {PendingAppointmentStatus,ApprovedAppointmentStatus,OnGoingAppointmentStatus,CanceledAppointmentStatus,CompleteAppointmentStatus};
        public static readonly string[] ActiveAppointmentStatuses = {PendingAppointmentStatus,ApprovedAppointmentStatus,OnGoingAppointmentStatus};
        public static readonly string[] WorkSlotStatuses = {AvailableWorkSlotStatus,NotAvailableWorkSlotStatus,TakenWorkSlotStatus};
        public static readonly string[] PromotionalCodeStatuses = {ActivePromotionalCodeStatus, InActivePromotionalCodeStatus, CanceledPromotionalCodeStatus};
        public static readonly string[] ArticleStatuses = {ActiveArticleStatus, InActiveArticleStatus};
        public static readonly string[] NotificationStatuses = {PendingNotificationStatus, DeliveredNotificationStatus, SeenNotificationStatus, CanceledNotificationStatus};
        
        public static readonly ViolationType ManagerApproveViolationId = new ViolationType()
            {Id = 1, Name = "Manager Failed to Approve of Disapprove an appointment"};
        
        public static ReadOnlyCollection<ViolationType> ViolationTypes { get; } = new ReadOnlyCollection<ViolationType>(
            new ViolationType[] { 
                ManagerApproveViolationId
            }
        );

        
    }
}