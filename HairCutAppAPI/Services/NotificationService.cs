using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.NotificationDTOs;
using HairCutAppAPI.DTOs.PromotionalCodeDTOs;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NotificationService(IRepositoryWrapper repositoryWrapper, IHttpContextAccessor httpContextAccessor)
        {
            _repositoryWrapper = repositoryWrapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> UpdateToSeen(int id)
        {
            var notification = await _repositoryWrapper.Notification.FindSingleByConditionAsync(noti =>
                noti.Id == id && noti.Status.ToLower() == GlobalVariables.DeliveredNotificationStatus.ToLower());
            if (notification is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Active Notification with Id {id} not found");
            }

            var currentUserId = GetCurrentUserId();
            if (notification.UserId != currentUserId)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Current user is not the owner of this notification");
            }

            notification.Status = GlobalVariables.SeenNotificationStatus;
            notification.LastUpdate = DateTime.Now;

            var result = await _repositoryWrapper.Notification.UpdateAsync(notification, notification.Id);
            
            return new CustomHttpCodeResponse(200,"", result.Status);
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> UserAdvancedGetNotification(UserAdvancedGetNotificationDTO dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.SortBy) && !UserAdvancedGetNotificationDTO.OrderingParams.Contains(dto.SortBy.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"OrderBy must be: " + string.Join(", ", UserAdvancedGetNotificationDTO.OrderingParams));
            }

            var currentUserId = GetCurrentUserId();
            
            var result = await _repositoryWrapper.Notification.UserAdvancedGetPromotionalCodes(dto, currentUserId);
            return new CustomHttpCodeResponse(200, "" , result);
        }
        
        private int GetCurrentUserId()
        {
            int currentUserId;
            if (_httpContextAccessor.HttpContext == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"No current user is active");
            }

            try
            {
                //Get Current customer Id
                currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            catch (ArgumentNullException e)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Current User Id not Found");
            }

            return currentUserId;
        }
    }
}