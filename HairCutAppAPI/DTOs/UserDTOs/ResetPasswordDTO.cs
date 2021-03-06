using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs
{
    public class ResetPasswordDTO
    {
        [Required]
        public string Token { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MinLength(3), MaxLength(50)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        
        [Required]
        [MinLength(3), MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}