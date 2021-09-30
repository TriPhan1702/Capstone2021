using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs
{
    public class GoogleUserDTO
    {
        [Required]
        public string IdToken { get; set; }
    }
}