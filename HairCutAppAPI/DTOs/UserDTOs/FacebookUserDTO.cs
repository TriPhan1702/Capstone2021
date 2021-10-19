using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.UserDTOs
{
    public class FacebookUserDTO
    {
        [Required]
        public string AccessToken { get; set; }
    }
}