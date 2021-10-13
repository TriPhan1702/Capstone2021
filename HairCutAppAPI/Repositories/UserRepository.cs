using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using HairCutAppAPI.Data;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.DTOs.WorkSlotDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class UserRepository : RepositoryBase<AppUser>, IUserRepository
    {
        private readonly HDBContext _hdbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserRepository(HDBContext hdbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(hdbContext)
        {
            _hdbContext = hdbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<PagedList<GetUserListResponseDTO>> AdvancedGetUsers(PaginationParams paginationParams)
        {
            var query = _hdbContext.Users.Include(user => user.UserRole).ThenInclude(userRole => userRole.Role).Select(user => user.ToGetUserListResponseDTO());
            return await PagedList<GetUserListResponseDTO>.CreateAsync(query, paginationParams.PageNumber,
                paginationParams.PageSize);
        }

        public async Task<AppUser> GetUserByUserNameAsync(string username)
        {
            return await _hdbContext.Users.SingleOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<IdentityResult> CreateUsingUserManagerAsync(AppUser user, string password)
        {
            //Save New User to Database
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> AddToRoleAsync(AppUser user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<SignInResult> CheckPasswordAsync(AppUser user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(user, password, false);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(AppUser user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<AppUser> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> ResetPasswordAsync(AppUser user, string token, string password)
        {
            return await _userManager.ResetPasswordAsync(user, token, password);
        }

        public async Task<bool> CheckRole(AppUser user, string role)
        {
            return await _userManager.IsInRoleAsync(user, role);
        }
    }
}