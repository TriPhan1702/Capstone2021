using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs
{
    public class SocialUserDTO
    {
        [Required]
        public string IdToken { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}