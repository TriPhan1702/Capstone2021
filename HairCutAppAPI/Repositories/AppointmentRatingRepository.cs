using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.DTOs.AppointmentRatingDTOs;
using HairCutAppAPI.DTOs.ArticleDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class AppointmentRatingRepository : RepositoryBase<AppointmentRating>, IAppointmentRatingRepository
    {
        private readonly HDBContext _hdbContext;

        public AppointmentRatingRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }
        
        public async Task<PagedList<AdvancedGetAppointmentRatingResponseDTO>> AdvancedGetRatings(AdvancedGetAppointmentRatingDTO dto)
        {
            var query = _hdbContext.AppointmentRatings.AsQueryable();
            
            //If there Id filtering
            if (dto.FilterIds != null && dto.FilterIds.Any())
            {
                query = query.Where(rating => 
                    dto.FilterIds.Contains(rating.Id));
            }
            
            //If there appointment Id filtering
            if (dto.FilterAppointmentIds != null && dto.FilterAppointmentIds.Any())
            {
                query = query.Where(rating =>
                    dto.FilterAppointmentIds.Contains(rating.AppointmentId));
            }
            
            //If there's sorting
            if (!string.IsNullOrWhiteSpace(dto.SortBy))
            {
                query = dto.SortBy switch
                {
                    "id_asc" => query.OrderBy(rating => rating.Id),
                    "id_desc" => query.OrderByDescending(rating => rating.Id),
                    "appointmentid_asc" => query.OrderBy(rating => rating.AppointmentId),
                    "appointmentid_desc" => query.OrderByDescending(rating => rating.AppointmentId),
                    "rating_asc" => query.OrderBy(rating => rating.Rating),
                    "rating_desc" => query.OrderByDescending(rating => rating.Rating),
                    _ => query
                };
            }

            return await PagedList<AdvancedGetAppointmentRatingResponseDTO>.CreateAsync(
                query.Select(article => article.ToAdvancedGetAppointmentRatingResponseDTO()), dto.PageNumber,
                dto.PageSize);
        }
    }
}