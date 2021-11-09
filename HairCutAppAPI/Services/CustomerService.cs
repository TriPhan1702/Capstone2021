using System;
using System.Collections.Generic;
using System.Linq;
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
using HairCutAppAPI.Utilities.ImageUpload;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoService;

        public CustomerService(IRepositoryWrapper repositoryWrapper, IMapper mapper, ITokenService tokenService, IHttpContextAccessor httpContextAccessor, IPhotoService photoService)
        {
            _repositoryWrapper = repositoryWrapper;
            _httpContextAccessor = httpContextAccessor;
            _photoService = photoService;
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> Register(CreateCustomerDto dto)
        {
            //Check if User exists
            if (await UserExists(dto.Email))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Email already Exists");
            }
        
            // from Dto to AppUser
            var newUser = dto.ToNewAppUser(dto.FullName, dto.Password);
        
            var customer = new Customer()
            {
                User = newUser,
                FullName = dto.FullName,
            };
            
            //If there's image
            if (dto.ImageFile != null)
            {
                var imageUploadResult = await _photoService.AppPhotoAsync(dto.ImageFile);
                //If there's error
                if (imageUploadResult.Error != null)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,imageUploadResult.Error.Message);
                }

                customer.User.AvatarUrl = imageUploadResult.SecureUrl.AbsoluteUri;
            }
        
            //Save New User to Database
            var result = await _repositoryWrapper.Customer.CreateAsync(customer);
        
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
            var customer = await _repositoryWrapper.Customer.GetCustomerDetailFromUserId(userId);
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

        public async Task<ActionResult<CustomHttpCodeResponse>> GetAllCustomers()
        {
            return new CustomHttpCodeResponse(200, "",
                (await _repositoryWrapper.Customer.GetAllCustomersWithDetail()).ToList().Select(customer => customer.ToCustomerDetailDTO()));
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> UpdateCustomer(UpdateCustomerDTO dto)
        {
            var currentUserId = GetCurrentUserId();

            var customer = await _repositoryWrapper.Customer.GetCustomerDetailFromUserId(currentUserId);
            if (customer is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Customer with UserId {currentUserId} not found");
            }

            customer = dto.CompareAndUpdateCustomer(customer);

            var result = _repositoryWrapper.Customer.UpdateAsync(customer, customer.Id);
            
            return new CustomHttpCodeResponse(200,"Customer profile updated", true);
        }

        #region Private Functions
        //Check if user exists by username and email
        private async Task<bool> UserExists(string email)
        {
            return await _repositoryWrapper.User.AnyAsync(u => u.Email == email.ToLower());
        }
        
        private int GetCurrentUserId()
        {
            int currentUserId;
            if (_httpContextAccessor.HttpContext == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"No current user is active");
            }

            try
            {
                //Get Current customer Id
                currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            catch (ArgumentNullException e)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Current User Id not Found");
            }

            return currentUserId;
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

        #endregion Private Functions
        
        
    }
}