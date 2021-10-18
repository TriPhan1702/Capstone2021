using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.JWTToken;
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

        public CustomerService(IRepositoryWrapper repositoryWrapper, IMapper mapper, ITokenService tokenService)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _tokenService = tokenService;
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
        
        //Check if user exists by username and email
        private async Task<bool> UserExists(string email)
        {
            return await _repositoryWrapper.User.AnyAsync(u => u.Email == email.ToLower());
        }
    }
}