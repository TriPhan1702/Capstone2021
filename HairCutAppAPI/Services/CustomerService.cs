using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.DTOs.CustomerDTO;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using HairCutAppAPI.Utilities.JWTToken;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace HairCutAppAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerService(IRepositoryWrapper repositoryWrapper, IMapper mapper, ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> Register(CreateCustomerDto dto)
        {
            //Check if User exists
            if (await UserExists(dto.Email))
            {
                return new CustomHttpCodeResponse(400, "Email already Exists");
            }
        
            // from Dto to AppUser
            var newUser = dto.ToNewAppUser(dto.Password);
        
            var customer = new Customer()
            {
                User = newUser,
                FullName = dto.FullName,
            };
        
            //Save New User to Database
            var result = await _repositoryWrapper.Customer.CreateAsync(customer);
            var user =  await _repositoryWrapper.User.FindSingleByConditionAsync(u =>u.Id == result.Id);
        
            return new CustomHttpCodeResponse(200, "Customer added", result.Id);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetCustomerDetail(int userId)
        {
            var currentUserId = GetCurrentUserId();
            var currentUserRole = GetCurrentUserRole();

            //If current user is a customer, check if the requested customer detail belong to current user
            if (currentUserRole.ToLower() == GlobalVariables.CustomerRole.ToLower())
            {
                if (userId != currentUserId)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.Unauthorized, $"Current customer is not the owner of this information");
                }
            }

            //Get customer from database
            var customer = await _repositoryWrapper.Customer.GetCustomerDetail(userId);
            if (customer is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Customer with UserId {userId} not found");
            }

            return new CustomHttpCodeResponse(200, "", customer.ToCustomerDetailDTO());
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetCustomers(AdvancedGetCustomerDTO advancedGetCustomerDTO)
        {
            if (!string.IsNullOrWhiteSpace(advancedGetCustomerDTO.SortBy) && !AdvancedGetCustomerDTO.OrderingParams.Contains(advancedGetCustomerDTO.SortBy.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"OrderBy must be: " + string.Join(", ", AdvancedGetCustomerDTO.OrderingParams));
            }
            
            var result = await _repositoryWrapper.Customer.AdvancedGetCustomers(advancedGetCustomerDTO);
            return new CustomHttpCodeResponse(200, "" , result);
        }

        //Check if user exists by username and email
        private async Task<bool> UserExists(string email)
        {
            return await _repositoryWrapper.User.AnyAsync(u => u.Email == email.ToLower());
        }
        
        private int GetCurrentUserId()
        {
            int customerId;
            if (_httpContextAccessor.HttpContext == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"No current user is active");
            }

            try
            {
                //Get Current customer Id
                customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            catch (ArgumentNullException e)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Current User Id not Found");
            }

            return customerId;
        }
        
        private string GetCurrentUserRole()
        {
            string role;
            if (_httpContextAccessor.HttpContext == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"No current user is active");
            }

            try
            {
                //Get Current customer Id
                role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            }
            catch (ArgumentNullException e)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Current User Id not Found");
            }

            return role;
        }
    }
}