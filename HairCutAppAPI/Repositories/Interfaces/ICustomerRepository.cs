using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.CustomerDTO;
using HairCutAppAPI.DTOs.UserDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Identity;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<Customer> GetCustomerDetail(int userId);
        Task<PagedList<CustomerDetailDTO>> AdvancedGetCustomers(AdvancedGetCustomerDTO advancedGetCustomerDTO);
        Task<IEnumerable<Customer>> GetAllCustomersWithDetail();
    }
}