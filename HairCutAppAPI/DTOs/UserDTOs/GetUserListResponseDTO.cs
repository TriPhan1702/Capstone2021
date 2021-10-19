namespace HairCutAppAPI.DTOs.UserDTOs
{
    public class GetUserListResponseDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarUrl { get; set; }
    }
}