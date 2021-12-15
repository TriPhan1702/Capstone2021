using System.Collections.Generic;
using System.Collections.ObjectModel;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.AppointmentDTOs
{
    public class CustomerAdvancedGetAppointmentDTO : PaginationParams
    {
        public static ReadOnlyCollection<string> OrderingParams { get; } = new ReadOnlyCollection<string>(
            new string[] { "appointmentid_asc", "appointmentid_desc",
                "customeruserid_asc", "customeruserid_desc", 
                "customerid_asc", "customerid_desc", 
                "customername_asc", "customername_desc", 
                "comboid_asc", "comboid_desc", 
                "comboidname_asc", "comboidname_desc", 
                "salonid_asc", "salonid_desc", 
                "salonname_asc", "salonname_desc", 
                "status_asc", "status_desc",
                "startdate_asc","startdate_desc",
                "enddate_asc","enddate_desc",
                "createddate_asc","createddate_desc",
                "lastupdate_asc","lastupdate_desc",
                "totalprice_desc, toalprice_asc"
            }
        );
        
        public ICollection<string> Statuses { get; set; }
        public ICollection<int> ComboIds { get; set; }
        public ICollection<int> SalonIds { get; set; }
        public string ComboName { get; set; }
        public string SalonName { get; set; }
        public string MinCreatedDate { get; set; }
        public string MaxCreatedDate { get; set; }
        public string MinLastUpdate { get; set; }
        public string MaxLastUpdate { get; set; }
        public string MinDate { get; set; }
        public string MaxDate { get; set; }
        public long MinTotalPrice { get; set; }
        public long MaxTotalPrice { get; set; }
        public string SortBy { get; set; }

        public AdvancedGetAppointmentsDTO ToAdvancedGetAppointmentsResponseDTO(int customerUserId)
        {
            return new AdvancedGetAppointmentsDTO()
            {
                Statuses = Statuses,
                ComboIds = ComboIds,
                SalonIds = SalonIds,
                ComboName = ComboName,
                CustomerName = null,
                CustomerIds = null,
                MaxDate = MaxDate,
                MinDate = MinDate,
                PageNumber = PageNumber,
                PageSize = PageSize,
                SalonName = SalonName,
                SortBy = SortBy,
                CustomerUserIds = new List<int>(){customerUserId},
                MaxCreatedDate = MaxCreatedDate,
                MaxLastUpdate = MaxLastUpdate,
                MaxTotalPrice = MaxTotalPrice,
                MinCreatedDate = MinCreatedDate,
                MinLastUpdate = MinLastUpdate,
                MinTotalPrice = MinTotalPrice,
                StaffId = -1,
                StaffUserIds = -1
            };
        }
        
        public AdvancedGetAppointmentsDTO StaffToAdvancedGetAppointmentsResponseDTO(int customerUserId)
        {
            return new AdvancedGetAppointmentsDTO()
            {
                Statuses = Statuses,
                ComboIds = ComboIds,
                SalonIds = SalonIds,
                ComboName = ComboName,
                CustomerName = null,
                CustomerIds = null,
                MaxDate = MaxDate,
                MinDate = MinDate,
                PageNumber = PageNumber,
                PageSize = PageSize,
                SalonName = SalonName,
                SortBy = SortBy,
                CustomerUserIds = null,
                MaxCreatedDate = MaxCreatedDate,
                MaxLastUpdate = MaxLastUpdate,
                MaxTotalPrice = MaxTotalPrice,
                MinCreatedDate = MinCreatedDate,
                MinLastUpdate = MinLastUpdate,
                MinTotalPrice = MinTotalPrice,
                StaffUserIds = customerUserId,
                StaffId = -1
            };
        }
    }
}