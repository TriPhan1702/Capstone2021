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

        public UserRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }

        // public async Task<PagedList<GetUserListResponseDTO>> AdvancedGetUsers(PaginationParams paginationParams)
        // {
        //     var query = _hdbContext.Users.Include(user => user.UserRole).ThenInclude(userRole => userRole.Role).Select(user => user.ToGetUserListResponseDTO());
        //     return await PagedList<GetUserListResponseDTO>.CreateAsync(query, paginationParams.PageNumber,
        //         paginationParams.PageSize);
        // }

        public async Task<AppUser> GetUserByEmailAsync(string email)
        {
            return await _hdbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> CheckRole(string email, string role)
        {
            return await _hdbContext.Users.AnyAsync(appUser => appUser.Email == email && appUser.Role.ToLower() == role.ToLower());
        }
    }
}