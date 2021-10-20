using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.DTOs.SalonDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;

namespace HairCutAppAPI.Repositories
{
    public class SalonRepository : RepositoryBase<Salon>, ISalonRepository
    {
        private readonly HDBContext _hdbContext;

        public SalonRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }

        public async Task<PagedList<AdvancedGetSalonResponseDTO>> AdvancedGetSalons(AdvancedGetSalonDTO advancedGetSalonDTO)
        {
            var query = _hdbContext.Salons.AsQueryable();
            //If there's status filtering
            if (advancedGetSalonDTO.Statuses != null && advancedGetSalonDTO.Statuses.Any())
            {
                query = query.Where(salon =>
                    advancedGetSalonDTO.Statuses.Select(status => status.ToLower()).Contains(salon.Status.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(advancedGetSalonDTO.Name))
            {
                query = query.Where(salon => salon.Name.ToLower().Contains((advancedGetSalonDTO.Name.ToLower())));
            }

            try
            {
                //If there's CreatedDate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetSalonDTO.MinCreatedDate))
                {
                    var date = DateTime.ParseExact(advancedGetSalonDTO.MinCreatedDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(salon => salon.CreatedDate >= date);
                }

                //If there's CreatedDate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetSalonDTO.MaxCreatedDate))
                {
                    var date = DateTime.ParseExact(advancedGetSalonDTO.MaxCreatedDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(salon => salon.CreatedDate <= date);
                }

                //If there's LastUpdate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetSalonDTO.MinLastUpdate))
                {
                        var date = DateTime.ParseExact(advancedGetSalonDTO.MinLastUpdate,
                            GlobalVariables.DateTimeFormat,
                            CultureInfo.InvariantCulture);
                        query = query.Where(salon => salon.LastUpdate >= date);
                }
                
                //If there's LastUpdate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetSalonDTO.MaxLastUpdate))
                {
                    var date = DateTime.ParseExact(advancedGetSalonDTO.MaxLastUpdate,
                        GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(salon => salon.LastUpdate <= date);
                }
            }
            catch (FormatException)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, GlobalVariables.DateTimeFormat);
            }


            //If there's sorting
            if (!string.IsNullOrWhiteSpace(advancedGetSalonDTO.SortBy))
            {
                query = advancedGetSalonDTO.SortBy switch
                {
                    "id_asc" => query.OrderBy(salon => salon.Id),
                    "id_desc" => query.OrderByDescending(salon => salon.Id),
                    "name_asc" => query.OrderBy(salon => salon.Name),
                    "name_desc" => query.OrderByDescending(salon => salon.Name),
                    "status_asc" => query.OrderBy(salon => salon.Status),
                    "status_desc" => query.OrderByDescending(salon => salon.Status),
                    "createddate_asc" => query.OrderBy(salon => salon.CreatedDate),
                    "createddate_desc" => query.OrderByDescending(salon => salon.CreatedDate),
                    "lastupdate_asc" => query.OrderBy(salon => salon.LastUpdate),
                    "lastupdate_desc" => query.OrderByDescending(salon => salon.LastUpdate),
                    _ => query
                };
            }

            return await PagedList<AdvancedGetSalonResponseDTO>.CreateAsync(
                query.Select(salon => salon.ToAdvancedGetSalonResponseDTO()), advancedGetSalonDTO.PageNumber,
                advancedGetSalonDTO.PageSize);
        }
    }
}