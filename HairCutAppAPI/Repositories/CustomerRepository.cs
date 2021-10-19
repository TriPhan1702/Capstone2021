﻿using System.Linq;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.DTOs.CustomerDTO;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly HDBContext _hdbContext;

        public CustomerRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }

        public async Task<Customer> GetCustomerDetail(int userId)
        {
            return await _hdbContext.Customers.Include(customer => customer.User).FirstOrDefaultAsync(customer => customer.UserId == userId);
        }

        public async Task<PagedList<CustomerDetailDTO>> AdvancedGetCustomers(AdvancedGetCustomerDTO advancedGetCustomerDTO)
        {
            var query = _hdbContext.Customers.Include(customer => customer.User).AsQueryable();
            //If there's role filtering
            if (advancedGetCustomerDTO.Roles != null && advancedGetCustomerDTO.Roles.Any())
            {
                query = query.Where(customer => advancedGetCustomerDTO.Roles.Select(role=>role.ToLower()).Contains(customer.User.Role.ToLower()));
            }
            //If there's status filtering
            if (advancedGetCustomerDTO.Statuses != null && advancedGetCustomerDTO.Statuses.Any())
            {
                query = query.Where(customer => advancedGetCustomerDTO.Statuses.Select(status=>status.ToLower()).Contains(customer.User.Status.ToLower()));
            }

            //If there's sorting
            if (!string.IsNullOrWhiteSpace(advancedGetCustomerDTO.SortBy))
            {
                query = advancedGetCustomerDTO.SortBy switch
                {
                    "userid_asc" => query.OrderBy(customer => customer.User.Id),
                    "userid_desc" => query.OrderByDescending(customer => customer.User.Id),
                    "customerid_asc" => query.OrderBy(customer => customer.Id),
                    "customerid_desc" => query.OrderByDescending(customer => customer.Id),
                    "email_asc" => query.OrderBy(customer => customer.User.Email),
                    "email_desc" => query.OrderByDescending(customer => customer.Id),
                    "fullname_asc" => query.OrderBy(customer => customer.User.Email),
                    "fullname_desc" => query.OrderByDescending(customer => customer.Id),
                    "status_asc"  => query.OrderBy(customer => customer.User.Status),
                    "status_desc" => query.OrderByDescending(customer => customer.User.Status),
                    "role_asc"  => query.OrderBy(customer => customer.User.Role),
                    "role_desc" => query.OrderByDescending(customer => customer.User.Role),
                    _ => query
                };
            }
            
            return await PagedList<CustomerDetailDTO>.CreateAsync(query.Select(customer => customer.ToCustomerDetailDTO()), advancedGetCustomerDTO.PageNumber,
                advancedGetCustomerDTO.PageSize);
        }
    }
}