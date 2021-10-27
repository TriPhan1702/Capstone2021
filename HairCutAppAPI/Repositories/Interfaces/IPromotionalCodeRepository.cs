using System.Threading.Tasks;
using HairCutAppAPI.DTOs.AppointmentDTOs;
using HairCutAppAPI.DTOs.PromotionalCodeDTOs;
using HairCutAppAPI.DTOs.SalonDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IPromotionalCodeRepository : IRepositoryBase<PromotionalCode>
    {
        Task<PagedList<AdvancedGetPromotionalCodesResponseDTO>> AdvancedGetPromotionalCodes(AdvancedGetPromotionalCodesDTO dto);
        Task<PromotionalCode> GetOnePromotionalWithSalon(int id);
    }
}