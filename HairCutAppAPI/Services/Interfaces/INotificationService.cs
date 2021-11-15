using System.Threading.Tasks;
using HairCutAppAPI.DTOs.NotificationDTOs;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface INotificationService
    {
        /// <summary>
        /// DEBUG
        /// </summary>
        Task<ActionResult<CustomHttpCodeResponse>> SendNotification(int id);
        Task<ActionResult<CustomHttpCodeResponse>> UpdateToSeen(int id);
        Task<ActionResult<CustomHttpCodeResponse>> UserAdvancedGetNotification(UserAdvancedGetNotificationDTO dto);
    }
}