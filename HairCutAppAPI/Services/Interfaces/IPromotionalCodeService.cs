using System.Threading.Tasks;
using HairCutAppAPI.DTOs.PromotionalCodeDTOs;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IPromotionalCodeService
    {
        Task<ActionResult<CustomHttpCodeResponse>> CreatePromotionalCode(CreatePromotionalCodeDTO createPromotionalCodeDTO);
        Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetPromotionalCodes(AdvancedGetPromotionalCodesDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> UpdatePromotionalCode(UpdatePromotionalCodeDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> ValidateCodeForAppointment(ValidateCodeForAppointmentDTO dto);
    }
}