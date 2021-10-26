using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.DTOs.ComboDTOs;
using HairCutAppAPI.DTOs.ServiceDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class ComboRepository : RepositoryBase<Combo>, IComboRepository
    {
        private readonly HDBContext _hdbContext;

        public ComboRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }

        public async Task<Combo> GetAComboComboDetails(int id)
        {
            return (await _hdbContext.Combos.Where(c => c.Id == id).Include(c => c.ComboDetails).ToListAsync()).First();
        }
        
        public async Task<IEnumerable<Combo>> GetActiveCombosWithDetailsAndServiceDetails()
        {
            return await _hdbContext.Combos.Include(c=>c.ComboDetails).ThenInclude(detail => detail.Service).Where(combo => combo.Status == GlobalVariables.ActiveComboStatus).ToListAsync();
        }
        
        public async Task<IEnumerable<Combo>> GetCombosWithDetails()
        {
            return await _hdbContext.Combos.Include(c=>c.ComboDetails).ToListAsync();
        }

        public async Task<Combo> GetOneComboWithDetails(int comboId)
        {
            return await _hdbContext.Combos.Include(c=>c.ComboDetails).SingleOrDefaultAsync(combo => combo.Id == comboId);
        }

        public async Task<Combo> GetOneComboWithDetailsAndServiceDetails(int comboId)
        {
            return await _hdbContext.Combos.Include(c=>c.ComboDetails).ThenInclude(detail => detail.Service).SingleOrDefaultAsync(combo => combo.Id == comboId);
        }

        public async Task<PagedList<AdvancedGetCombosResponseDTO>> AdvancedGetCombos(AdvancedGetCombosDTO advancedGetCombosDTO)
        {
            var query = _hdbContext.Combos.Include(combo => combo.ComboDetails).ThenInclude(detail => detail.Service).AsQueryable();
            //If there's status filtering
            if (advancedGetCombosDTO.Statuses != null && advancedGetCombosDTO.Statuses.Any())
            {
                query = query.Where(combo =>
                    advancedGetCombosDTO.Statuses.Select(status => status.ToLower()).Contains(combo.Status.ToLower()));
            }

            //If There's Name Filtering
            if (!string.IsNullOrWhiteSpace(advancedGetCombosDTO.Name))
            {
                query = query.Where(combo => combo.Name.ToLower().Contains(advancedGetCombosDTO.Name.ToLower()));
            }
            
            //If there's min price filtering
            if (advancedGetCombosDTO.MinPrice >= 0)
            {
                query = query.Where(combo => combo.ComboDetails.Sum(detail => detail.Service.Price) >= advancedGetCombosDTO.MinPrice);
            }
            
            //If there's max price filtering
            if (advancedGetCombosDTO.MaxPrice >= 0)
            {
                query = query.Where(combo => combo.ComboDetails.Sum(detail => detail.Service.Price) <= advancedGetCombosDTO.MaxPrice);
            }
            
            //If there's min duration filtering
            if (advancedGetCombosDTO.MinDuration >= 0)
            {
                query = query.Where(combo => combo.Duration >= advancedGetCombosDTO.MinDuration);
            }
            
            //If there's max duration filtering
            if (advancedGetCombosDTO.MaxDuration >= 0)
            {
                query = query.Where(combo => combo.ComboDetails.Sum(detail => detail.Service.Price) <= advancedGetCombosDTO.MaxPrice);
            }

            try
            {
                //If there's CreatedDate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetCombosDTO.MinCreatedDate))
                {
                    var date = DateTime.ParseExact(advancedGetCombosDTO.MinCreatedDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(combo => combo.CreatedDate >= date);
                }

                //If there's CreatedDate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetCombosDTO.MaxCreatedDate))
                {
                    var date = DateTime.ParseExact(advancedGetCombosDTO.MaxCreatedDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(combo => combo.CreatedDate <= date);
                }

                //If there's LastUpdate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetCombosDTO.MinLastUpdate))
                {
                        var date = DateTime.ParseExact(advancedGetCombosDTO.MinLastUpdate,
                            GlobalVariables.DateTimeFormat,
                            CultureInfo.InvariantCulture);
                        query = query.Where(combo => combo.LastUpdated >= date);
                }
                
                //If there's LastUpdate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetCombosDTO.MaxLastUpdate))
                {
                    var date = DateTime.ParseExact(advancedGetCombosDTO.MaxLastUpdate,
                        GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(combo => combo.LastUpdated <= date);
                }
            }
            catch (FormatException)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, GlobalVariables.DateTimeFormat);
            }


            //If there's sorting
            if (!string.IsNullOrWhiteSpace(advancedGetCombosDTO.SortBy))
            {
                query = advancedGetCombosDTO.SortBy switch
                {
                    "id_asc" => query.OrderBy(combo => combo.Id),
                    "id_desc" => query.OrderByDescending(combo => combo.Id),
                    "name_asc" => query.OrderBy(combo => combo.Name),
                    "name_desc" => query.OrderByDescending(combo => combo.Name),
                    "status_asc" => query.OrderBy(combo => combo.Status),
                    "status_desc" => query.OrderByDescending(combo => combo.Status),
                    "price_asc" => query.OrderBy(combo => combo.ComboDetails.Sum(detail => detail.Service.Price)),
                    "price_desc" => query.OrderByDescending(combo => combo.ComboDetails.Sum(detail => detail.Service.Price)),
                    "duration_asc" => query.OrderBy(combo => combo.Duration),
                    "duration_desc" => query.OrderByDescending(combo => combo.Duration),
                    "createddate_asc" => query.OrderBy(combo => combo.CreatedDate),
                    "createddate_desc" => query.OrderByDescending(combo => combo.CreatedDate),
                    "lastupdate_asc" => query.OrderBy(combo => combo.LastUpdated),
                    "lastupdate_desc" => query.OrderByDescending(combo => combo.LastUpdated),
                    _ => query
                };
            }

            return await PagedList<AdvancedGetCombosResponseDTO>.CreateAsync(
                query.Select(combo => combo.ToAdvancedGetCombosResponseDTO()), advancedGetCombosDTO.PageNumber,
                advancedGetCombosDTO.PageSize);
        }
    }
}