using System.Threading.Tasks;
using HairCutAppAPI.DTOs.NotificationDTOs;
using HairCutAppAPI.DTOs.PromotionalCodeDTOs;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class NotificationController : BaseApiController
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        
        /// <summary>
        /// for registered users to get list of all statuses that a notification can have
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("all_appointment_statuses")]
        public ActionResult<CustomHttpCodeResponse> GetAllNotificationStatuses()
        {
            return new CustomHttpCodeResponse(200, "", GlobalVariables.NotificationStatuses);
        }
        
        /// <summary>
        /// For User to turn their own notification to seen
        /// </summary>
        /// <param name="id">Notification's Id</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("see_notification/{id}")]
        public async Task<ActionResult<CustomHttpCodeResponse>> SeeNotification(int id)
        {
            return await _notificationService.UpdateToSeen(id);
        }
        
        /// <summary>
        /// For users to get their own notifications
        /// </summary>
        /// <param name="dto">Empty ot null fields will not be changed, negative number value = null</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("advanced_get_notification")]
        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetNotification(
            UserAdvancedGetNotificationDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as UserAdvancedGetNotificationDTO;
            
            var notification = await _notificationService.UserAdvancedGetNotification(dto);
            return notification;
        }

        /// <summary>
        /// Id is appointment ID
        /// </summary>
        /// <param name="id">AppointmentID</param>
        /// <returns></returns>
        [HttpGet("debug_send_notification")]
        public async Task<ActionResult<CustomHttpCodeResponse>> DEBUGSendNotification(int id)
        {
            return await _notificationService.SendNotification(id);
        }
    }
}