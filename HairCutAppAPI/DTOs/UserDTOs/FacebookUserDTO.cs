using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs
{
    public class FacebookUserDTO
    {
        [Required]
        public string AccessToken { get; set; }
    }
}