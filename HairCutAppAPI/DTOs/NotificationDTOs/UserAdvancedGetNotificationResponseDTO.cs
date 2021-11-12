namespace HairCutAppAPI.DTOs.NotificationDTOs
{
    public class UserAdvancedGetNotificationResponseDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
        public int? AppointmentId { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string LastUpdate { get; set; }
    }
}