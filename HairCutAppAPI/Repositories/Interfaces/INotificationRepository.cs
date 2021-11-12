using System.Threading.Tasks;
using HairCutAppAPI.DTOs.NotificationDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface INotificationRepository : IRepositoryBase<Notification>
    {
        Task<PagedList<UserAdvancedGetNotificationResponseDTO>> UserAdvancedGetPromotionalCodes(UserAdvancedGetNotificationDTO dto, int userId);
    }
}