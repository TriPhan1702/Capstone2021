using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.SalonDTOs;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.ImageUpload;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface ISalonService
    {
        Task<ActionResult<CustomHttpCodeResponse>> CustomerGetSalonList(CustomerGetSalonListDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> CreateSalon(CreateSalonDTO salonDTO);
        
        Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetSalons(AdvancedGetSalonDTO advancedGetSalonDTO);
        Task<ActionResult<CustomHttpCodeResponse>> UpdateSalon(UpdateSalonDTO updateSalonDTO);
        Task<ActionResult<CustomHttpCodeResponse>> UploadSalonImage(UploadImageDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> DeactivateSalon(int salonId);
    }
}