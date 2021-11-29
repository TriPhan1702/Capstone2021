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
        public static readonly string[] PaymentTypes = {"direct", "momo"};
        
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
        //TG để tạo appointment trước
        public const int TimeToCreateAppointmentInAdvanced = 60;
        //TG để approve appointment trước
        public const int TimeToConfirmAppointmentInAdvanced = 30;
        //TG để hoàn thành 1 appointment, nếu không, gửi notification đến manager
        public const int TimeToFinishAppointment = 120;
        //TG để nhắc khách hàng sắp tới cuộc hẹn
        public const int TimeToRemindAppointment = 15;
        public const int MaximumCreateAppointmentDay = 7;
        
        //Name of roles
        public const string AdministratorRole = "administrator";
        public const string ManagerRole = "manager";
        public const string StylistRole = "stylist";
        public const string BeauticianRole = "beautician";
        public const string CustomerRole = "customer";
        public static readonly string[] Roles = {AdministratorRole, ManagerRole, StylistRole,BeauticianRole,CustomerRole};
        public static readonly string[] UserRolesWithoutSeparateTable = {AdministratorRole};
        public static readonly string[] AppointmentPerformingRoles = {StylistRole, BeauticianRole};
        public static readonly string[] StaffTypes = {StylistRole, BeauticianRole, ManagerRole};

        //Statuses
        public const string ActiveUserStatus = "active";
        public const string InActiveUserStatus = "inactive";
        public const string NewUserStatus = ActiveUserStatus;
        public static readonly string[] UserStatuses = {ActiveUserStatus, InActiveUserStatus};
        
        //Appointment Status
        public const string PendingAppointmentStatus = "pending";
        public const string ApprovedAppointmentStatus = "approved";
        public const string CompleteAppointmentStatus = "completed";
        public const string CanceledAppointmentStatus = "canceled";
        public const string OnGoingAppointmentStatus = "ongoing";
        public const string NewAppointmentStatus = PendingAppointmentStatus;
        //Các status có thể bị cancel
        public static readonly string[] ActiveAppointmentStatuses = {PendingAppointmentStatus,ApprovedAppointmentStatus,OnGoingAppointmentStatus};
        public static readonly string[] AppointmentStatuses = {
            PendingAppointmentStatus,
            ApprovedAppointmentStatus,
            OnGoingAppointmentStatus,
            CanceledAppointmentStatus,
            CompleteAppointmentStatus};
        
        // Work Slot status
        public const string AvailableWorkSlotStatus = "available";
        public const string NotAvailableWorkSlotStatus = "not available";
        public const string TakenWorkSlotStatus = "taken";
        public static readonly string[] WorkSlotStatuses = {AvailableWorkSlotStatus,NotAvailableWorkSlotStatus,TakenWorkSlotStatus};
        
        //Promotional Code Status
        public const string ActivePromotionalCodeStatus = "active";
        public const string InActivePromotionalCodeStatus = "inactive";
        public const string CanceledPromotionalCodeStatus = "canceled";
        public const string NewPromotionalCodeStatus = ActivePromotionalCodeStatus;
        public static readonly string[] PromotionalCodeStatuses = {ActivePromotionalCodeStatus, InActivePromotionalCodeStatus, CanceledPromotionalCodeStatus};
        
        //Combo Status
        public const string ActiveComboStatus = "active";
        public const string InActiveComboStatus = "inactive";
        public static readonly string[] ComboStatuses = {ActiveComboStatus, InActiveComboStatus};
        
        //Combo Detail Status
        public const string ActiveComboDetailStatus = "active";
        public const string InActiveComboDetailStatus = "inactive";
        
        //Service Status
        public const string ActiveServiceStatus = "active";
        public const string InActiveServiceStatus = "inactive";
        public static readonly string[] ServiceStatuses = {ActiveServiceStatus, InActiveServiceStatus};
        
        //Device Status
        public const string ActiveDeviceStatus = "active";
        public const string InActiveDeviceStatus = "inactive";
        public static readonly string[] DeviceStatuses = {ActiveDeviceStatus, InActiveDeviceStatus};
        
        //Salon Status
        public const string ActiveSalonStatus = "active";
        public const string NewSalonStatus = ActiveSalonStatus;
        public const string InActiveSalonStatus = "inactive";
        public static readonly string[] SalonStatuses = {ActiveSalonStatus, InActiveSalonStatus};
        
        //Article Status
        public const string ActiveArticleStatus = "active";
        public const string InActiveArticleStatus = "inactive";
        public const string NewArticleStatus = ActiveArticleStatus;
        public static readonly string[] ArticleStatuses = {ActiveArticleStatus, InActiveArticleStatus};
        
        //Notification Status
        public const string PendingNotificationStatus = "pending";
        public const string DeliveredNotificationStatus = "delivered";
        public const string SeenNotificationStatus = "seen";
        public const string CanceledNotificationStatus = "canceled";
        public static readonly string[] NotificationStatuses = {PendingNotificationStatus, DeliveredNotificationStatus, SeenNotificationStatus, CanceledNotificationStatus};
        
        // Các Kiểu notification
        public const string AppointmentCreatedNotification = "appointment_created";
        public const string AppointmentApprovedNotification = "appointment_approved";
        public const string AppointmentCanceledNotification = "appointment_canceled";
        public const string AppointmentCompleteNotification = "appointment_complete";
        public const string AppointmentReminderNotification = "appointment_reminder";
        public const string AppointmentCompleteReminderNotification = "appointment_complete_reminder";

        public static readonly ViolationType ManagerApproveViolationId = new ViolationType()
            {Id = 1, Name = "Manager Failed to Approve of Disapprove an appointment"};
        
        public static ReadOnlyCollection<ViolationType> ViolationTypes { get; } = new ReadOnlyCollection<ViolationType>(
            new ViolationType[] { 
                ManagerApproveViolationId
            }
        );

        
    }
}