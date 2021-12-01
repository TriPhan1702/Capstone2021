namespace HairCutAppAPI.DTOs.UserDTOs
{
    public class CurrentUserDTO
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public string AvatarUrl { get; set; }
        public string Token { get; set; }
        
        public string FullName { get; set; }
    }
}