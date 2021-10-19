using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.UserDTOs
{
    public class SocialLoginDTO
    {
        [Required]
        public string Token { get; set; }
        
        [Required]
        public string Platform { get; set; }

        public string DeviceId { get; set; }
        
        public string DeviceToken { get; set; }
    }
}