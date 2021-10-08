using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ServiceDTOs;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ServiceService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<UpdateServiceResponseDto> UpdateService(UpdateServiceDto updateServiceDto)
        {
            //Validate request
            if (updateServiceDto.Status != null)
            {
                ValidateServiceStatus(updateServiceDto.Status);
            }
            if (updateServiceDto.Price != null)
            {
                ValidateServicePrice(updateServiceDto.Price.Value);
            }

            //Get service from database
            var service = await _repositoryWrapper.Service.FindSingleByConditionAsync(s => s.Id == updateServiceDto.Id);
            //Check if service is found
            if (service is null) 
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    $"Service with the id {updateServiceDto.Id} doesn't exist");
            }
            //Map the different fields to service entity
            service = updateServiceDto.CompareUpdateService(service);
            //Update to database
            service = await _repositoryWrapper.Service.UpdateAsync(service, service.Id);
            
            return service.ToUpdateServiceResponseDto();
        }

        public async Task<ActionResult<ICollection<ServiceDTO>>> GetAllServices()
        {
            var services = await _repositoryWrapper.Service.FindAllAsync();
            var result = new List<ServiceDTO>();
            foreach (var service in services)
            {
                result.Add(service.ToServiceDTO());
            }

            return result;
        }

        public async Task<ActionResult<int>> CreateService(CreateServiceDTO createServiceDTO)
        {
            //Validate request
            ValidateServiceStatus(createServiceDTO.Status);
            ValidateServiceDuration(createServiceDTO.Duration);
            ValidateServicePrice(createServiceDTO.Price);

            var newService = createServiceDTO.ToNewService();

            //Create new Service in database
            var result = await _repositoryWrapper.Service.CreateAsync(newService);
            
            return new OkObjectResult(result.Id);
        }

        private void ValidateServiceStatus(string status)
        {
            //Check if status is valid
            if (!GlobalVariables.ServiceStatuses.Contains(status.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    "Service Status invalid, must be: " + string.Join(", ", GlobalVariables.ServiceStatuses));
            }
        }
        
        private void ValidateServiceDuration(int duration)
        {
            //Check Duration
            if (duration <= 0)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Duration is invalid");
            }
        }
        
        private void ValidateServicePrice(decimal price)
        {
            //Check Price
            if (price <= 0)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Price is invalid");
            }
        }
    }
}