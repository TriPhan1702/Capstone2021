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
            //Check if status is valid
            if (!GlobalVariables.ServiceStatuses.Contains(createServiceDTO.Status.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    "Service Status invalid, must be: " + string.Join(", ", GlobalVariables.ServiceStatuses));
            }
            
            //Check Duration
            if (createServiceDTO.Duration <= 0)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Duration is invalid");
            }
            
            //Check Price
            if (createServiceDTO.Price <= 0)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Price is invalid");
            }

            var newService = createServiceDTO.ToNewService();

            //Create new Service in database
            var result = await _repositoryWrapper.Service.CreateAsync(newService);
            await _repositoryWrapper.SaveAllAsync();
            
            return new OkObjectResult(result.Id);
        }
    }
}