using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs
{
    //many-many table between user and role in database
    public class RegisterDTO
    {
        [Required]
        [MinLength(3), MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
    }
}