using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.DTOs.CustomerDTO;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Get profile of a customer
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetCustomerDetail(int id)
        {
            return await _customerService.GetCustomerDetail(id);
        }
        
        /// <summary>
        /// For admin, manager and staff
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("advanced_get_customers")]
        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetCustomers(
            AdvancedGetCustomerDTO advancedGetCustomerDTO)
        {
            //Trim All Strings in object
            advancedGetCustomerDTO = ObjectTrimmer.TrimObject(advancedGetCustomerDTO) as AdvancedGetCustomerDTO;
            var customers = await _customerService.AdvancedGetCustomers(advancedGetCustomerDTO);
            return customers;
        }
        
        /// <summary>
        /// Used by customer to create account
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<CustomHttpCodeResponse>> Register([FromBody]CreateCustomerDto dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as CreateCustomerDto;
            
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
            
            return await _customerService.Register(dto);
        }
    }
}