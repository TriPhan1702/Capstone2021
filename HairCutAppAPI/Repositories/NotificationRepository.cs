using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.DTOs.NotificationDTOs;
using HairCutAppAPI.DTOs.PromotionalCodeDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        private readonly HDBContext _hdbContext;

        public NotificationRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }
        
        public async Task<PagedList<UserAdvancedGetNotificationResponseDTO>> UserAdvancedGetPromotionalCodes(UserAdvancedGetNotificationDTO dto, int userId)
        {
            var query = _hdbContext.Notifications.AsQueryable();
            
            //Filter by user's Id
            query = query.Where(notification => notification.UserId == userId);
            
            //If there's status filtering
            if (dto.Statuses != null && dto.Statuses.Any())
            {
                query = query.Where(notification =>
                    dto.Statuses.Select(status => status.ToLower()).Contains(notification.Status.ToLower()));
            }
            
            //If there's Id filtering
            if (dto.FilterByIds != null && dto.FilterByIds.Any())
            {
                query = query.Where(notification => dto.FilterByIds.Contains(notification.Id));
            }
            
            //If there's AppointmentId filtering
            if (dto.FilterByAppointmentId != null && dto.FilterByAppointmentId.Any())
            {
                query = query.Where(notification => dto.FilterByAppointmentId.Contains(notification.AppointmentId.Value));
            }

            try
            {
                //If there's CreatedDate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MinCreatedDate))
                {
                    var date = DateTime.ParseExact(dto.MinCreatedDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(notification => notification.CreatedDate >= date);
                }

                //If there's CreatedDate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MaxCreatedDate))
                {
                    var date = DateTime.ParseExact(dto.MaxCreatedDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(notification => notification.CreatedDate <= date);
                }

                //If there's LastUpdate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MinLastUpdate))
                {
                        var date = DateTime.ParseExact(dto.MinLastUpdate,
                            GlobalVariables.DateTimeFormat,
                            CultureInfo.InvariantCulture);
                        query = query.Where(notification => notification.LastUpdate >= date);
                }
                
                //If there's LastUpdate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MaxLastUpdate))
                {
                    var date = DateTime.ParseExact(dto.MaxLastUpdate,
                        GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(notification => notification.LastUpdate <= date);
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
                    "id_asc" => query.OrderBy(notification => notification.Id),
                    "id_desc" => query.OrderByDescending(notification => notification.Id),
                    "userid_asc" => query.OrderBy(notification => notification.UserId),
                    "userid_desc" => query.OrderByDescending(notification => notification.UserId),
                    "appointmentid_asc" => query.OrderBy(notification => notification.AppointmentId),
                    "appointmentid_desc" => query.OrderByDescending(notification => notification.AppointmentId),
                    "status_asc" => query.OrderBy(notification => notification.Status),
                    "status_desc" => query.OrderByDescending(notification => notification.Status),
                    "createddate_asc" => query.OrderBy(notification => notification.CreatedDate),
                    "createddate_desc" => query.OrderByDescending(notification => notification.CreatedDate),
                    "lastupdate_asc" => query.OrderBy(notification => notification.LastUpdate),
                    "lastupdate_desc" => query.OrderByDescending(notification => notification.LastUpdate),
                    _ => query
                };
            }

            return await PagedList<UserAdvancedGetNotificationResponseDTO>.CreateAsync(
                query.Select(notification => notification.ToUserAdvancedGetNotificationResponseDTO()), dto.PageNumber,
                dto.PageSize);
        }
    }
}