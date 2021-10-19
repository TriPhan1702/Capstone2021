using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.UserDTOs
{
    public class CreateUserDTO
    {
        [Required]
        [EmailAddress]
        [RegularExpression(GlobalVariables.EmailRegex)]
        public string Email { get; set; }
        
        [Required]
        [MinLength(3), MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [MinLength(3), MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(GlobalVariables.PhoneNumberRegex, ErrorMessage = "Phone Number is Invalid")]
        public string PhoneNumber { get; set; }

        public AppUser ToNewUser(string password, string role)
        {
            using var hmac = new HMACSHA512();
            return new AppUser()
            {
                Email = Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key,
                Status = GlobalVariables.NewUserStatus,
                PhoneNumber = PhoneNumber,
                Role = role.ToLower()
            };
        }
    }
}