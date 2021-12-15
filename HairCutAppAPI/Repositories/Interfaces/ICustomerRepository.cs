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
        Task<IEnumerable<Customer>> GetAllCustomersOfSalon(int salonId);
        Task<Customer> GetCustomerDetailFromUserId(int userId);
        Task<PagedList<CustomerDetailDTO>> AdvancedGetCustomers(AdvancedGetCustomerDTO advancedGetCustomerDTO);
        Task<IEnumerable<Customer>> GetAllCustomersWithDetail();
    }
}