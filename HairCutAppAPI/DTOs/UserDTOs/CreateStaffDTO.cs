using System;
using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs
{
    public class CreateStaffDTO
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
        
        [MaxLength(500)]
        public string Description { get; set; }
        
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(?:[0-9]{10})$", ErrorMessage = "Phone Number has to have 10 numeric characters")]
        public string PhoneNumber { get; set; }
        
        public int SalonId { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string StaffType { get; set; }

        public Staff ToNewStaff(string passwordHash, string staffType, int salonId = -1)
        {
            
            var result = new Staff()
            {
                User = new AppUser()
                {
                    Email = Email,
                    NormalizedEmail = Email.ToUpper(),
                    EmailConfirmed = false,
                    UserName = UserName.ToLower(),
                    NormalizedUserName = UserName.ToUpper(),
                    PasswordHash = passwordHash,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Status = GlobalVariables.NewUserStatus,
                    PhoneNumber = PhoneNumber,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                },
                Description = Description,
                AppointmentsNumber = 0,
                SuccessfulAppointmentsNumber = 0,
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