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

        public async Task<CustomHttpCodeResponse> UpdateService(UpdateServiceDto updateServiceDto)
        {
            //Get service from database
            var service = await _repositoryWrapper.Service.FindSingleByConditionAsync(s => s.Id == updateServiceDto.Id);
            //Check if service is found
            if (service is null) 
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    $"không tìm thấy được Service với id {updateServiceDto.Id}");
            }
            //Map the different fields to service entity
            service = updateServiceDto.CompareUpdateService(service);
            //Update to database
            service = await _repositoryWrapper.Service.UpdateAsync(service, service.Id);
            
            return new CustomHttpCodeResponse(200,"Service Updated",service.ToUpdateServiceResponseDto()); 
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetAllServices()
        {
            var services = await _repositoryWrapper.Service.FindAllAsync();
            var result = new List<ServiceDTO>();
            foreach (var service in services)
            {
                result.Add(service.ToServiceDTO());
            }

            return new CustomHttpCodeResponse(200,"", result);
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> GetServiceDetail(int id)
        {
            var combo = await _repositoryWrapper.Service.FindSingleByConditionAsync(service => service.Id == id);
            return new CustomHttpCodeResponse(200,"", combo.ToServiceDTO());
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CreateService(CreateServiceDTO createServiceDTO)
        {
            //Validate request
            ValidateServicePrice(createServiceDTO.Price);
            ValidateServiceDuration(createServiceDTO.Duration);

            var newService = createServiceDTO.ToNewService();

            //Create new Service in database
            var result = await _repositoryWrapper.Service.CreateAsync(newService);
            
            return new CustomHttpCodeResponse(200, "Service đã được tạo",result.Id);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetServices(AdvancedGetServiceDTO advancedGetServiceDTO)
        {
            if (!string.IsNullOrWhiteSpace(advancedGetServiceDTO.SortBy) && !AdvancedGetServiceDTO.OrderingParams.Contains(advancedGetServiceDTO.SortBy.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"OrderBy Phải là: " + string.Join(", ", AdvancedGetServiceDTO.OrderingParams));
            }
            
            var result = await _repositoryWrapper.Service.AdvancedGetServices(advancedGetServiceDTO);
            return new CustomHttpCodeResponse(200, "" , result);
        }
        
        /// <summary>
        /// Check if price is positive number
        /// </summary>
        private void ValidateServicePrice(decimal price)
        {
            //Check Price
            if (price <= 0)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Giá Phải > 0");
            }
        }
        
        private void ValidateServiceDuration(int duration)
        {
            if (duration <= 0)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Chiều dài Service phải > 0");
            }
        }
    }
}