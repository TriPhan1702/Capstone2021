using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Http;

namespace HairCutAppAPI.DTOs.StaffDTOs
{
    public class CreateStaffDTO
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
        
        [MaxLength(500)]
        public string Description { get; set; }
        
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(GlobalVariables.PhoneNumberRegex, ErrorMessage = "Phone Number has to have 10 numeric characters")]
        public string PhoneNumber { get; set; }
        
        public int SalonId { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string StaffType { get; set; }
        
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }

        public Staff ToNewStaff(string fullName, string password, string staffType, int salonId = -1)
        {
            using var hmac = new HMACSHA512();
            
            var result = new Staff()
            {
                User = new AppUser()
                {
                    Email = Email,
                    FullName = fullName,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                    PasswordSalt = hmac.Key,
                    Status = GlobalVariables.NewUserStatus,
                    PhoneNumber = PhoneNumber,
                    Role = staffType,
                },
                Description = Description,
                FullName = FullName,
                StaffType = staffType,
            };

            if (salonId >= 0)
            {
                result.SalonId = salonId;
            }

            return result;
        }
    }
}