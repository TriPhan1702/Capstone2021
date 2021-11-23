using System.ComponentModel.DataAnnotations;
using System.Net;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;

namespace HairCutAppAPI.DTOs.StaffDTOs
{
    public class UpdateStaffDTO
    {
        [MinLength(3)]
        [MaxLength(50)]
        public string FullName { get; set; }
        
        [MaxLength(500)]
        public string Description { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(GlobalVariables.PhoneNumberRegex, ErrorMessage = "Phone Number has to have 10 numeric characters")]
        public string PhoneNumber { get; set; }
        
        public Staff CompareAndUpdateStaff(Staff staff)
        {
            var hasChanged = false;
            if (!string.IsNullOrWhiteSpace(FullName) && FullName.ToLower() != staff.FullName)
            {
                staff.FullName = FullName;
                staff.User.FullName = FullName;
                hasChanged = true;
            }

            if (!string.IsNullOrWhiteSpace(PhoneNumber) && PhoneNumber != staff.User.PhoneNumber)
            {
                staff.User.PhoneNumber = PhoneNumber;
                hasChanged = true;
            }
            
            if (!string.IsNullOrWhiteSpace(Description))
            {
                staff.Description = Description;
                hasChanged = true;
            }

            if (!hasChanged)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Không có gì thay đổi dựa trên thông tin từ request");
            }

            return staff;
        }
    }
}