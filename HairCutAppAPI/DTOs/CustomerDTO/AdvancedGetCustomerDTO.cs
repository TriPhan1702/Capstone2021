using System.Collections.Generic;
using System.Collections.ObjectModel;
using HairCutAppAPI.DTOs.UserDTOs;

namespace HairCutAppAPI.DTOs.CustomerDTO
{
    public class AdvancedGetCustomerDTO : AdvancedGetUserDTO
    {
        public new static ReadOnlyCollection<string> OrderingParams { get; } = new ReadOnlyCollection<string>(
            new string[] { "userid_asc", "userid_desc","customerid_asc","customerid_desc", "email_asc", "email_desc", "fullname_asc", "fullname_desc", "status_asc", "status_desc", "role_asc", "role_desc"}
        );
    }
}