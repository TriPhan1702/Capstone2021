using System.Threading.Tasks;
using HairCutAppAPI.DTOs.AppointmentRatingDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IAppointmentRatingRepository : IRepositoryBase<AppointmentRating>
    {
        Task<PagedList<AdvancedGetAppointmentRatingResponseDTO>> AdvancedGetRatings(AdvancedGetAppointmentRatingDTO dto);
    }
}