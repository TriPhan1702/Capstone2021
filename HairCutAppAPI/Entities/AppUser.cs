using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Identity;

namespace HairCutAppAPI.Entities
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }
        
        public byte[] PasswordSalt { get; set; }
        
        [Required]
        [MinLength(1), MaxLength(20)]
        public string Status { get; set; }
        
        public string Role { get; set; }
        
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
        
        public Device Device { get; set; }

        //Numeric only, length 10
        [StringLength(10)]
        [RegularExpression(GlobalVariables.PhoneNumberRegex, ErrorMessage = "Must be 10 digits")]
        public string PhoneNumber { get; set; }
        
        [Url]
        public string AvatarUrl { get; set; }

        public GetUserListResponseDTO ToGetUserListResponseDTO()
        {
            var result = new GetUserListResponseDTO
            {
                Id = Id,
                Email = Email,
                Status = Status,
                AvatarUrl = AvatarUrl,
                PhoneNumber = PhoneNumber,
                Role = Role
            };

            return result;
        }
    }
}