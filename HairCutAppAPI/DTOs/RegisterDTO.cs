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
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(?:[0-9]{10})$", ErrorMessage = "Phone Number has to have 10 numeric characters")]
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