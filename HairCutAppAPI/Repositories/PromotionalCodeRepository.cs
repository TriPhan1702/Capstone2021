using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.DTOs.ComboDTOs;
using HairCutAppAPI.DTOs.PromotionalCodeDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class PromotionalCodeRepository : RepositoryBase<PromotionalCode>, IPromotionalCodeRepository
    {
        private readonly HDBContext _hdbContext;

        public PromotionalCodeRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }

        public async Task<PagedList<AdvancedGetPromotionalCodesResponseDTO>> AdvancedGetPromotionalCodes(AdvancedGetPromotionalCodesDTO dto)
        {
            var query = _hdbContext.PromotionalCodes.AsQueryable();
            //If there's status filtering
            if (dto.Statuses != null && dto.Statuses.Any())
            {
                query = query.Where(code =>
                    dto.Statuses.Select(status => status.ToLower()).Contains(code.Status.ToLower()));
            }
            
            //If there's IsUniversal filtering
            if (dto.IsUniversal >= 0)
            {
                var tempBool = dto.IsUniversal != 0;
                query = query.Where(code =>code.IsUniversal == tempBool);
            }

            //If There's Code Filtering
            if (!string.IsNullOrWhiteSpace(dto.Code))
            {
                query = query.Where(code => code.Code.ToLower().Contains(dto.Code.ToLower()));
            }
            
            //If there's min price filtering
            if (dto.MinPercentage >= 0)
            {
                query = query.Where(code => code.Percentage >= dto.MinPercentage);
            }
            
            //If there's max price filtering
            if (dto.MinPercentage >= 0)
            {
                query = query.Where(code => code.Percentage <= dto.MaxPercentage);
            }
            
            //If there's min duration filtering
            if (dto.MinUsesPerCustomer >= 0)
            {
                query = query.Where(code => code.UsesPerCustomer >= dto.MinUsesPerCustomer);
            }
            
            //If there's max duration filtering
            if (dto.MaxUsesPerCustomer >= 0)
            {
                query = query.Where(code => code.UsesPerCustomer <= dto.MaxUsesPerCustomer);
            }

            try
            {
                //If there's CreatedDate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MinCreatedDate))
                {
                    var date = DateTime.ParseExact(dto.MinCreatedDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(code => code.CreatedDate >= date);
                }

                //If there's CreatedDate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MaxCreatedDate))
                {
                    var date = DateTime.ParseExact(dto.MaxCreatedDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(code => code.CreatedDate <= date);
                }

                //If there's LastUpdate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MinLastUpdate))
                {
                        var date = DateTime.ParseExact(dto.MinLastUpdate,
                            GlobalVariables.DateTimeFormat,
                            CultureInfo.InvariantCulture);
                        query = query.Where(code => code.LastUpdate >= date);
                }
                
                //If there's LastUpdate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MaxLastUpdate))
                {
                    var date = DateTime.ParseExact(dto.MaxLastUpdate,
                        GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(code => code.LastUpdate <= date);
                }
                
                //If there's StartDate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MinStartDate))
                {
                    var date = DateTime.ParseExact(dto.MinStartDate,
                        GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(code => code.StartDate >= date);
                }
                
                //If there's StartDate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MaxStartDate))
                {
                    var date = DateTime.ParseExact(dto.MaxStartDate,
                        GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(code => code.StartDate <= date);
                }
                
                //If there's ExpirationDate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MinExpirationDate))
                {
                    var date = DateTime.ParseExact(dto.MinExpirationDate,
                        GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(code => code.ExpirationDate >= date);
                }
                
                //If there's ExpirationDate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MaxExpirationDate))
                {
                    var date = DateTime.ParseExact(dto.MaxExpirationDate,
                        GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(code => code.ExpirationDate <= date);
                }
            }
            catch (FormatException)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, GlobalVariables.DateTimeFormat);
            }


            //If there's sorting
            if (!string.IsNullOrWhiteSpace(dto.SortBy))
            {
                query = dto.SortBy switch
                {
                    "id_asc" => query.OrderBy(code => code.Id),
                    "id_desc" => query.OrderByDescending(code => code.Id),
                    "code_asc" => query.OrderBy(code => code.Code),
                    "code_desc" => query.OrderByDescending(code => code.Code),
                    "status_asc" => query.OrderBy(code => code.Status),
                    "status_desc" => query.OrderByDescending(code => code.Status),
                    "percentage_asc" => query.OrderBy(code => code.Percentage),
                    "percentage_desc" => query.OrderByDescending(code => code.Percentage),
                    "usespercustomer_asc" => query.OrderBy(code => code.UsesPerCustomer),
                    "usespercustomer_desc" => query.OrderByDescending(code => code.UsesPerCustomer),
                    "createddate_asc" => query.OrderBy(code => code.CreatedDate),
                    "createddate_desc" => query.OrderByDescending(code => code.CreatedDate),
                    "lastupdate_asc" => query.OrderBy(code => code.LastUpdate),
                    "lastupdate_desc" => query.OrderByDescending(code => code.LastUpdate),
                    "startdate_asc" => query.OrderBy(code => code.StartDate),
                    "startdate_desc" => query.OrderByDescending(code => code.StartDate),
                    "expirationdate_asc" => query.OrderBy(code => code.ExpirationDate),
                    "expirationdate_desc" => query.OrderByDescending(code => code.ExpirationDate),
                    "isuniversal_asc" => query.OrderBy(code => code.IsUniversal),
                    "isuniversal_desc" => query.OrderByDescending(code => code.IsUniversal),
                    _ => query
                };
            }

            return await PagedList<AdvancedGetPromotionalCodesResponseDTO>.CreateAsync(
                query.Select(code => code.ToAdvancedGetPromotionalCodesResponseDTO()), dto.PageNumber,
                dto.PageSize);
        }

        public async Task<PromotionalCode> GetOnePromotionalWithSalon(int id)
        {
            return await _hdbContext.PromotionalCodes.Include(code => code.SalonsCodes)
                .ThenInclude(codesSalons => codesSalons.Salon).FirstOrDefaultAsync(code => code.Id == id);
        }
    }
}