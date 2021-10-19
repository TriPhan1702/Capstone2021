using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.UserDTOs
{
    public class GoogleUserDTO
    {
        [Required]
        public string IdToken { get; set; }
    }
}