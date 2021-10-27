using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.DTOs.CustomerDTO;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<ActionResult<CustomHttpCodeResponse>> Register(CreateCustomerDto dto);
        Task<ActionResult<CustomHttpCodeResponse>> GetCustomerDetail(int userId);
        Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetCustomers(AdvancedGetCustomerDTO advancedGetCustomerDTO);
    }
}