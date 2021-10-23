using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.SalonDTOs;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class SalonService : ISalonService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public SalonService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CustomerGetSalonList()
        {
            var salons = await _repositoryWrapper.Salon.FindByConditionAsync(s=>s.Status == GlobalVariables.SalonStatuses[0]);
            return  new CustomHttpCodeResponse(200, "",salons?.Select(salon => salon.ToCustomerGetSalonListDTO()).ToList());
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CreateSalon(CreateSalonDTO salonDTO)
        {
            var newSalon = salonDTO.ToNewSalon();

            var result = await _repositoryWrapper.Salon.CreateAsync(newSalon);

            return new CustomHttpCodeResponse(200, "", result.ToCreateSalonResponseDTO());
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetSalons(AdvancedGetSalonDTO advancedGetSalonDTO)
        {
            if (!string.IsNullOrWhiteSpace(advancedGetSalonDTO.SortBy) && !AdvancedGetSalonDTO.OrderingParams.Contains(advancedGetSalonDTO.SortBy.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"OrderBy must be: " + string.Join(", ", AdvancedGetSalonDTO.OrderingParams));
            }
            
            var result = await _repositoryWrapper.Salon.AdvancedGetSalons(advancedGetSalonDTO);
            return new CustomHttpCodeResponse(200, "" , result);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> UpdateSalon(UpdateSalonDTO updateSalonDTO)
        {
            var salon = await _repositoryWrapper.Salon.FindSingleByConditionAsync(salon => salon.Id == updateSalonDTO.Id);
            if (salon is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Salon with id {updateSalonDTO.Id} not found");
            }

            if (!GlobalVariables.SalonStatuses.Contains(updateSalonDTO.Status.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"status {updateSalonDTO.Status} is not valid, must be: " + string.Join(", ", GlobalVariables.SalonStatuses));
            }

            salon = updateSalonDTO.CompareAndMapToSalon(salon);

            salon = await _repositoryWrapper.Salon.UpdateAsync(salon, salon.Id);
            
            return new CustomHttpCodeResponse(200,"Salon Update",salon.ToUpdateSalonResponseDTO());
        }
    }
}