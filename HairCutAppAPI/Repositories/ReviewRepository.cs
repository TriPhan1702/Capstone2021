using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.DTOs.ReviewDTOs;
using HairCutAppAPI.DTOs.SalonDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        private readonly HDBContext _hdbContext;

        public ReviewRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }

        public async Task<PagedList<ReviewDTO>> AdvancedGetReview(AdvancedGetReviewDTO dto)
        {
            var query = _hdbContext.Reviews.Include(review => review.Author).Include(review => review.Salon).AsQueryable();

            if (dto.Ids != null && dto.Ids.Any())
            {
                query = query.Where(review => dto.Ids.Contains(review.Id));
            }
            
            if (dto.SalonIds != null && dto.SalonIds.Any())
            {
                query = query.Where(review => dto.SalonIds.Contains(review.SalonId));
            }
            
            if (dto.CustomerIds != null && dto.CustomerIds.Any())
            {
                query = query.Where(review => dto.CustomerIds.Contains(review.AuthorId));
            }
            
            if (dto.CustomerUserIds != null && dto.CustomerUserIds.Any())
            {
                query = query.Where(review => dto.CustomerUserIds.Contains(review.Author.UserId));
            }
            
            if (!string.IsNullOrWhiteSpace(dto.ContainCustomerName))
            {
                query = query.Where(review => review.Author.FullName.ToLower().Contains((dto.ContainCustomerName.ToLower())));
            }
            
            if (!string.IsNullOrWhiteSpace(dto.ContainSalonName))
            {
                query = query.Where(review => review.Salon.Name.ToLower().Contains((dto.ContainSalonName.ToLower())));
            }
            
            if (dto.Rating >= 0)
            {
                var tempBool = dto.Rating != 0;
                query = query.Where(review => review.Rating == tempBool);
            }

            try
            {
                //If there's CreatedDate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MinCreatedDate))
                {
                    var date = DateTime.ParseExact(dto.MinCreatedDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(review => review.CreatedDate >= date);
                }

                //If there's CreatedDate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MaxCreatedDate))
                {
                    var date = DateTime.ParseExact(dto.MaxCreatedDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(review => review.CreatedDate <= date);
                }

                // //If there's LastUpdate Filtering
                // if (!string.IsNullOrWhiteSpace(dto.MinLastUpdate))
                // {
                //         var date = DateTime.ParseExact(dto.MinLastUpdate,
                //             GlobalVariables.DateTimeFormat,
                //             CultureInfo.InvariantCulture);
                //         query = query.Where(salon => salon.LastUpdate >= date);
                // }
                //
                // //If there's LastUpdate Filtering
                // if (!string.IsNullOrWhiteSpace(dto.MaxLastUpdate))
                // {
                //     var date = DateTime.ParseExact(dto.MaxLastUpdate,
                //         GlobalVariables.DateTimeFormat,
                //         CultureInfo.InvariantCulture);
                //     query = query.Where(salon => salon.LastUpdate <= date);
                // }
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
                    "id_asc" => query.OrderBy(review => review.Id),
                    "id_desc" => query.OrderByDescending(review => review.Id),
                    "salonid_asc" => query.OrderBy(review => review.SalonId),
                    "salonid_desc" => query.OrderByDescending(review => review.SalonId),
                    "customerid_asc" => query.OrderBy(review => review.AuthorId),
                    "customerid_desc" => query.OrderByDescending(review => review.AuthorId),
                    "customeruserid_asc" => query.OrderBy(review => review.Author.UserId),
                    "customeruserid_desc" => query.OrderByDescending(review => review.Author.UserId),
                    "salonname_asc" => query.OrderBy(review => review.Salon.Name),
                    "salonname_desc" => query.OrderByDescending(review => review.Salon.Name),
                    "customername_asc" => query.OrderBy(review => review.Author.FullName),
                    "customername_desc" => query.OrderByDescending(review => review.Author.FullName),
                    "rating_asc" => query.OrderBy(review => review.Rating),
                    "rating_desc" => query.OrderByDescending(review => review.Rating),
                    "createddate_asc" => query.OrderBy(review => review.CreatedDate),
                    "createddate_desc" => query.OrderByDescending(salon => salon.CreatedDate),
                    _ => query
                };
            }

            return await PagedList<ReviewDTO>.CreateAsync(
                query.Select(review => review.ToReviewDTO()), dto.PageNumber,
                dto.PageSize);
        }
    }
}