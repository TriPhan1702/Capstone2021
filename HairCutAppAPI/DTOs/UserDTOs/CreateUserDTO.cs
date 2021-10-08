using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs
{
    public class CreateUserDTO
    {
        [Required]
        [MinLength(3), MaxLength(100)]
        public string UserName { get; set; }
        
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
        
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(?:[0-9]{10})$", ErrorMessage = "Phone Number is Invalid")]
        public string PhoneNumber { get; set; }

        public AppUser ToNewUser( string password)
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
                Status = GlobalVariables.NewUserStatus,
                PhoneNumber = PhoneNumber,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };
        }
    }
}