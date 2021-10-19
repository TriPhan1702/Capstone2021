using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.UserDTOs
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public string DeviceId { get; set; }
        
        public string DeviceToken { get; set; }
    }
}