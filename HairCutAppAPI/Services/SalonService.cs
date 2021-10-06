using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.SalonDTOs;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
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

        public async Task<ActionResult<ICollection<CustomerGetSalonListDTO>>> CustomerGetSalonList()
        {
            var salons = await _repositoryWrapper.Salon.FindByConditionAsync(s=>s.Status == GlobalVariables.SalonStatuses[0]);
            return salons?.Select(salon => salon.ToCustomerGetSalonListDTO()).ToList();
        }

        public async Task<ActionResult<CreateSalonResponseDTO>> CreateSalon(CreateSalonDTO salonDTO)
        {
            var newSalon = salonDTO.ToNewSalon();

            var result = await _repositoryWrapper.Salon.CreateAsync(newSalon);

            return new OkObjectResult(result.ToCreateSalonResponseDTO());
        }
    }
}