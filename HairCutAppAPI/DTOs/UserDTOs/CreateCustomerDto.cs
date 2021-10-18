using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs
{
    //many-many table between user and role in database
    public class CreateCustomerDto
    {
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
        [RegularExpression(GlobalVariables.EmailRegex)]
        public string Email { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(GlobalVariables.PhoneNumberRegex, ErrorMessage = "Phone Number is Invalid")]
        public string PhoneNumber { get; set; }

        public AppUser ToNewAppUser(string password)
        {
            using var hmac = new HMACSHA512();
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            var passwordSalt = hmac.Key;
            
            return new AppUser()
            {
                Email = Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = GlobalVariables.NewUserStatus,
                PhoneNumber = PhoneNumber,
                Role = GlobalVariables.CustomerRole,
            };
        }
    }
}