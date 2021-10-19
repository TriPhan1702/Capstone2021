using System.Collections.Generic;
using System.Collections.ObjectModel;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.UserDTOs
{
    public class AdvancedGetUserDTO : PaginationParams
    {
        public static ReadOnlyCollection<string> OrderingParams { get; } = new ReadOnlyCollection<string>(
            new string[] { "id_asc", "id_desc", "email_asc", "email_desc", "status_asc", "status_desc", "role_asc", "role_desc"}
        );
        
        //For filtering role
        public ICollection<string> Roles { get; set; }
        
        public ICollection<string> Statuses { get; set; }
        
        public string SortBy { get; set; }

        
    }
}