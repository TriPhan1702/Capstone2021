using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using HairCutAppAPI.Data;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.DTOs.UserDTOs;
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

        public async Task<PagedList<GetUserListResponseDTO>> AdvancedGetUsers(AdvancedGetUserDTO advancedGetUserDTO)
        {
            var query = _hdbContext.Users.AsQueryable();
            //If there's role filtering
            if (advancedGetUserDTO.Roles != null && advancedGetUserDTO.Roles.Any())
            {
                query = query.Where(user => advancedGetUserDTO.Roles.Select(role=>role.ToLower()).Contains(user.Role.ToLower()));
            }
            //If there's status filtering
            if (advancedGetUserDTO.Statuses != null && advancedGetUserDTO.Statuses.Any())
            {
                query = query.Where(user => advancedGetUserDTO.Statuses.Select(status=>status.ToLower()).Contains(user.Status.ToLower()));
            }
            

            //If there's sorting
            if (!string.IsNullOrWhiteSpace(advancedGetUserDTO.SortBy))
            {
                query = advancedGetUserDTO.SortBy switch
                {
                    "id_asc" => query.OrderBy(user => user.Id),
                    "id_desc" => query.OrderByDescending(user => user.Id),
                    "email_asc" => query.OrderBy(user => user.Email),
                    "email_desc" => query.OrderByDescending(user => user.Id),
                    "status_asc"  => query.OrderBy(user => user.Status),
                    "status_desc" => query.OrderByDescending(user => user.Status),
                    "role_asc"  => query.OrderBy(user => user.Role),
                    "role_desc" => query.OrderByDescending(user => user.Role),
                    _ => query
                };
            }
            
            return await PagedList<GetUserListResponseDTO>.CreateAsync(query.Select(user => user.ToGetUserListResponseDTO()), advancedGetUserDTO.PageNumber,
                advancedGetUserDTO.PageSize);
        }

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