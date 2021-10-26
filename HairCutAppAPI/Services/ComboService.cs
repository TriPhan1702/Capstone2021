using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ComboDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class ComboService : IComboService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ComboService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> UpdateCombo(UpdateComboDTO updateComboDTO)
        {
            //If Status is not null of empty
            if (!string.IsNullOrWhiteSpace(updateComboDTO.Status))
            {
                //Validate status
                ValidateComboStatus(updateComboDTO.Status.ToLower());
            }
            
            // Get Combo from database
            var combo = await _repositoryWrapper.Combo.FindSingleByConditionAsync(c => c.Id == updateComboDTO.Id);
            if (combo == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Couldn't Combo in database");
            }
            
            // If services in DTO is not empty, check and update ComboDetail List
            if (updateComboDTO.Services != null)
            {
                //Get list of ServiceId of Combo from Database
                var comboDetails = await _repositoryWrapper.ComboDetail.FindByConditionAsync(cd => cd.ComboId == updateComboDTO.Id) as List<ComboDetail>;
                //Covert ComboDetails to a list of ComboDetail id
                var comboDetailsIds = new List<int>();
                if (comboDetails != null)
                {
                     comboDetailsIds = comboDetails.Select(cd => cd.Id).ToList();
                }
                //If the combo already has services
                if (comboDetails != null && comboDetails.Count>0)
                {
                    //If combo's service's Id is not in the new service list, delete
                    foreach (var cd in comboDetails.Where(cd => !updateComboDTO.Services.Contains(cd.Id)))
                    {
                        _repositoryWrapper.ComboDetail.DeleteWithoutSave(cd);
                    }
                }

                var addServicesIds = new List<int>();
                //Add new services
                foreach (var serviceId in updateComboDTO.Services)
                {
                    //If ids from the new list is not from the old 
                    if (!comboDetailsIds.Contains(serviceId))
                    {
                        addServicesIds.Add(serviceId);
                    }
                }
                //If addServicesIds is not null, add the ComboDetails with the corresponding services
                if (addServicesIds.Any())
                {
                    //Check if the add Services are valid
                    await CheckValidServices(addServicesIds);

                    //Add combo detail to database for each
                    foreach (var serviceId in addServicesIds)
                    {
                        var addServicesId = _repositoryWrapper.ComboDetail.CreateWithoutSaveAsync(new ComboDetail()
                        {
                            ComboId = updateComboDTO.Id,
                            ServiceId = serviceId,
                        });
                    }
                }
            }

            //Map the differences from dto to entity
            combo = updateComboDTO.CompareUpdateCombo(combo);
            
            await _repositoryWrapper.Combo.UpdateAsyncWithoutSave(combo, combo.Id);
            
            try
            {
                //Save all changes above to database 
                await _repositoryWrapper.SaveAllAsync();
            }
            catch (Exception )
            {
                //clear pending changes if fail
                _repositoryWrapper.DeleteChanges();
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError,
                    "Some thing went wrong went updating ComboDetail for Combo");
            }

            combo = await _repositoryWrapper.Combo.GetAComboComboDetails(updateComboDTO.Id);
            
            var result = combo.ToUpdateComboResponseDTO();
            //If the updated combo has ComboDetail, Add to the response DTO
            if (combo.ComboDetails.Any())
            {
                var services = await _repositoryWrapper.Service.FindByConditionAsync(s =>
                    combo.ComboDetails.Select(cd => cd.ServiceId).ToList().Contains(s.Id));
                result.Services = services.Select(s => new UpdateComboResponseServiceDTO()
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList();
            }
            
            
            return new CustomHttpCodeResponse(200,"",result);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetComboPrice(int id)
        {
            if (!await CheckComboExists(id))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Combo not found");
            }

            return new CustomHttpCodeResponse(200,"", await CalculateComboPrice(id));
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetAllActiveCombos()
        {
            //Get Active Combo
            var comboDetails = await _repositoryWrapper.Combo.GetActiveCombosWithDetailsAndServiceDetails();
            
            return new CustomHttpCodeResponse(200, "" , comboDetails.Select(c=>c.ToComboDTO()).ToList());
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CreateCombo(CreateComboDTO createComboDTO)
        {
            if (createComboDTO.Duration <= 0)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    "Com bo duration has to be more than 0");
            }
            ValidateComboStatus(createComboDTO.Status.ToLower());
            
            //Prepare new combo
            var newCombo = createComboDTO.ToNewCombo();

            // If services in DTo is not empty, check and prepare ComboDetail List
            if (createComboDTO.Services != null && createComboDTO.Services.Count != 0)
            {
                var comboDetails = await PrepareComboDetail(createComboDTO.Services, newCombo);
                newCombo.ComboDetails = comboDetails;
            }

            Combo result = null;
            try
            {
                result = await _repositoryWrapper.Combo.CreateAsync(newCombo);
            }
            catch (Exception e)
            {
                //clear pending changes if fail
                _repositoryWrapper.DeleteChanges();
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError,
                    "Some thing went wrong went creating ComboDetail for Combo");
            }
            
            return new CustomHttpCodeResponse(200,"",result.Id);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetCombos(AdvancedGetCombosDTO advancedGetCombosDTO)
        {
            if (!string.IsNullOrWhiteSpace(advancedGetCombosDTO.SortBy) && !AdvancedGetCombosDTO.OrderingParams.Contains(advancedGetCombosDTO.SortBy.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"OrderBy must be: " + string.Join(", ", AdvancedGetCombosDTO.OrderingParams));
            }
            
            var result = await _repositoryWrapper.Combo.AdvancedGetCombos(advancedGetCombosDTO);
            return new CustomHttpCodeResponse(200, "" , result);
        }

        /// <summary>
        /// Check if Service list is valid
        /// </summary>
        private async Task<bool> CheckValidServices(IEnumerable<int> serviceIds)
        {
            //Get list of id of all services in database
            var databaseServiceIds = await _repositoryWrapper.Service.GetAllIdAsync();
            
            //True if all id is in database
            return serviceIds.All(i => databaseServiceIds.Contains(i));
        }

        /// <summary>
        /// Prepare a combo's service list to be inserted
        /// </summary>
        private async Task<List<ComboDetail>> PrepareComboDetail(ICollection<int> serviceIds, Combo combo)
        {
            //Get Services in dto's service list from Database
            var services =
                (await _repositoryWrapper.Service.FindByConditionAsync(s => serviceIds.Contains(s.Id))).ToList();

            //Check if all Services are valid
            if (services.Count != serviceIds.Count)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Service list is invalid");
            }
            
            //Create list of Combo Detail
            var comboDetails = new List<ComboDetail>();
            foreach (var service in services)
            {
                comboDetails.Add(new ComboDetail()
                {
                    Combo = combo,
                    Service = service,
                });
            }

            return comboDetails;
        }

        /// <summary>
        /// Check if Combo exist in Database with Id
        /// </summary>
        private async Task<bool> CheckComboExists(int id)
        {
            return await _repositoryWrapper.Combo.AnyAsync(c => c.Id == id);
        }

        /// <summary>
        /// Calculate the price of a combo base on comboId from its services
        /// </summary>
        private async Task<decimal> CalculateComboPrice(int id)
        {
            var comboDetails = await _repositoryWrapper.ComboDetail.FindComboDetailWithService(id);
            if (comboDetails is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"ComboDetail not found");
            }

            var price = comboDetails.Sum(comboDetail => comboDetail.Service.Price);
            return price;
        }
        
        /// <summary>
        /// Check if status is valid
        /// </summary>
        private void ValidateComboStatus(string status)
        {
            //Check if status is valid
            if (!GlobalVariables.ServiceStatuses.Contains(status.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    "Combo Status invalid, must be: " + string.Join(", ", GlobalVariables.ComboStatuses));
            }
        }
    }
}