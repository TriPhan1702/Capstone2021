using System.ComponentModel.DataAnnotations;
using System.Net;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities.Errors;

namespace HairCutAppAPI.DTOs.StaffDTOs
{
    public class AdministratorUpdateStaffDTO
    {
        [Required]
        public int StaffId { get; set; }
        public string StaffType { get; set; }
        public string Status { get; set; }
        public int SalonId { get; set; }
        
        public Staff CompareAndUpdateStaff(Staff staff)
        {
            var hasChanged = false;
            if (!string.IsNullOrWhiteSpace(StaffType) && StaffType.ToLower() != staff.StaffType)
            {
                staff.StaffType = StaffType.ToLower();
                hasChanged = true;
            }

            if (!string.IsNullOrWhiteSpace(Status) && Status.ToLower() != staff.User.Status)
            {
                staff.User.Status = Status.ToLower();
            }
            
            if (SalonId > 0 && staff.SalonId != SalonId)
            {
                staff.SalonId = SalonId;
            }

            if (!hasChanged)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Không có gì thay đổi dựa trên thông tin từ request");
            }

            return staff;
        }
    }
}