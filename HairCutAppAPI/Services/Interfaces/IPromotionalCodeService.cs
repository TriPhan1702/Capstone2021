using System.Threading.Tasks;
using HairCutAppAPI.DTOs.PromotionalCodeDTOs;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IPromotionalCodeService
    {
        Task<CustomHttpCodeResponse> CreatePromotionalCode(CreatePromotionalCodeDTO createPromotionalCodeDTO);
    }
}