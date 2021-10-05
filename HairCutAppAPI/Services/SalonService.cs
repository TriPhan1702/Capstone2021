using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.SalonDTOs;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
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
            var salons = await _repositoryWrapper.Salon.FindAllAsync();
            if (salons is null)
            {
                return null;
            }
            
            var result = new List<CustomerGetSalonListDTO>();
            foreach (var salon in salons)
            {
                result.Add(salon.ToCustomerGetSalonListDTO());
            }

            return result;
        }

        public async Task<ActionResult<CreateSalonResponseDTO>> CreateSalon(CreateSalonDTO salonDTO)
        {
            var newSalon = salonDTO.ToNewSalon();

            var result = await _repositoryWrapper.Salon.CreateAsync(newSalon);

            return new OkObjectResult(result.ToCreateSalonResponseDTO());
        }
    }
}