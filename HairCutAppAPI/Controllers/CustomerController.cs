using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
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