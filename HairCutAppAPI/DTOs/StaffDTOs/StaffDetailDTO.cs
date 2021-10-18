namespace HairCutAppAPI.DTOs
{
    public class StaffDetailDTO
    {
        public int UserId { get; set; }
        public int StaffId { get; set; }
        public string FullName { get; set; }
        public string StaffType { get; set; }
        public string Description { get; set; }
        public int? SalonId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarUrl { get; set; }
    }
}