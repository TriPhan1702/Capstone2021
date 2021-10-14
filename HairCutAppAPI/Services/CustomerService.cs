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
        private readonly IPasswordHasher<AppUser> _passwordHasher;

        public CustomerService(IRepositoryWrapper repositoryWrapper, IMapper mapper, ITokenService tokenService, IPasswordHasher<AppUser> passwordHasher)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> Register(CreateCustomerDto dto)
        {
            //Check if User exists
            if (await UserExists(dto.UserName))
            {
                return new CustomHttpCodeResponse(400, "User name already Exists");
            }

            // from Dto to AppUser
            var newUser = dto.ToNewAppUser(_passwordHasher.HashPassword(null, dto.Password));

            var customer = new Customer()
            {
                User = newUser,
                FullName = dto.FullName,
            };

            //Save New User to Database
            var result = await _repositoryWrapper.Customer.CreateAsync(customer);

            //Save Customer's role
            var roleResult = await _repositoryWrapper.User.AddToRoleAsync(newUser, GlobalVariables.CustomerRole);
            if (!roleResult.Succeeded)
            {
                return new CustomHttpCodeResponse(500, "Could not add user to Customer Role", roleResult.Errors);
            }

            return new CustomHttpCodeResponse(200, "Customer added", result.Id);
        }
        
        //Check if user exists by username and email
        private async Task<bool> UserExists(string username)
        {
            return await _repositoryWrapper.User.AnyAsync(u => u.UserName == username.ToLower());
        }
    }
}