using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.DTOs.ServiceDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        private readonly HDBContext _hdbContext;

        public ServiceRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }

        public async Task<ICollection<int>> GetAllIdAsync()
        {
            return await _hdbContext.Services.Select(x => x.Id).ToListAsync();
        }

        public async Task<PagedList<ServiceDTO>> AdvancedGetServices(AdvancedGetServiceDTO advancedGetServiceDTO)
        {
            var query = _hdbContext.Services.AsQueryable();
            //If there's status filtering
            if (advancedGetServiceDTO.Statuses != null && advancedGetServiceDTO.Statuses.Any())
            {
                query = query.Where(service =>
                    advancedGetServiceDTO.Statuses.Select(status => status.ToLower()).Contains(service.Status.ToLower()));
            }

            //If There's Name Filtering
            if (!string.IsNullOrWhiteSpace(advancedGetServiceDTO.Name))
            {
                query = query.Where(service => service.Name.ToLower().Contains(advancedGetServiceDTO.Name.ToLower()));
            }
            
            //If there's min price filtering
            if (advancedGetServiceDTO.MinPrice >= 0)
            {
                query = query.Where(service => service.Price >= advancedGetServiceDTO.MinPrice);
            }
            
            //If there's min price filtering
            if (advancedGetServiceDTO.MaxPrice >= 0)
            {
                query = query.Where(service => service.Price <= advancedGetServiceDTO.MaxPrice);
            }

            try
            {
                //If there's CreatedDate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetServiceDTO.MinCreatedDate))
                {
                    var date = DateTime.ParseExact(advancedGetServiceDTO.MinCreatedDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(service => service.CreatedDate >= date);
                }

                //If there's CreatedDate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetServiceDTO.MaxCreatedDate))
                {
                    var date = DateTime.ParseExact(advancedGetServiceDTO.MaxCreatedDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(service => service.CreatedDate <= date);
                }

                //If there's LastUpdate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetServiceDTO.MinLastUpdate))
                {
                        var date = DateTime.ParseExact(advancedGetServiceDTO.MinLastUpdate,
                            GlobalVariables.DateTimeFormat,
                            CultureInfo.InvariantCulture);
                        query = query.Where(service => service.LastUpdated >= date);
                }
                
                //If there's LastUpdate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetServiceDTO.MaxLastUpdate))
                {
                    var date = DateTime.ParseExact(advancedGetServiceDTO.MaxLastUpdate,
                        GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(service => service.LastUpdated <= date);
                }
            }
            catch (FormatException)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, GlobalVariables.DateTimeFormat);
            }


            //If there's sorting
            if (!string.IsNullOrWhiteSpace(advancedGetServiceDTO.SortBy))
            {
                query = advancedGetServiceDTO.SortBy switch
                {
                    "id_asc" => query.OrderBy(service => service.Id),
                    "id_desc" => query.OrderByDescending(service => service.Id),
                    "name_asc" => query.OrderBy(service => service.Name),
                    "name_desc" => query.OrderByDescending(service => service.Name),
                    "status_asc" => query.OrderBy(service => service.Status),
                    "status_desc" => query.OrderByDescending(service => service.Status),
                    "price_asc" => query.OrderBy(service => service.Price),
                    "price_desc" => query.OrderByDescending(service => service.Price),
                    "createddate_asc" => query.OrderBy(service => service.CreatedDate),
                    "createddate_desc" => query.OrderByDescending(service => service.CreatedDate),
                    "lastupdate_asc" => query.OrderBy(service => service.LastUpdated),
                    "lastupdate_desc" => query.OrderByDescending(service => service.LastUpdated),
                    _ => query
                };
            }

            return await PagedList<ServiceDTO>.CreateAsync(
                query.Select(service => service.ToServiceDTO()), advancedGetServiceDTO.PageNumber,
                advancedGetServiceDTO.PageSize);
        }
    }
}