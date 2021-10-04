using System;
using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.DTOs
{
    //many-many table between user and role in database
    public class RegisterDTO
    {
        [Required]
        [MinLength(3), MaxLength(100)]
        public string UserName { get; set; }
        
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FullName { get; set; }
        
        [Required]
        [MinLength(3), MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [MinLength(3), MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        [EmailAddress]
        [RegularExpression(@"^[a-z0-9](\.?[a-z0-9]){5,}@g(oogle)?mail\.com$", ErrorMessage = "Must be Gmail")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"/^(0?)(3[2-9]|5[6|8|9]|7[0|6-9]|8[0-6|8|9]|9[0-4|6-9])[0-9]{7}$/", ErrorMessage = "Phone Number is Invalid")]
        public string PhoneNumber { get; set; }

        public AppUser ToNewAppUser(string password)
        {
            return new AppUser()
            {
                Email = Email,
                NormalizedEmail = Email.ToUpper(),
                EmailConfirmed = false,
                UserName = UserName.ToLower(),
                NormalizedUserName = UserName.ToUpper(),
                PasswordHash = password,
                SecurityStamp = Guid.NewGuid().ToString(),
                Status = "New",
                PhoneNumber = PhoneNumber,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };
        }
    }
}