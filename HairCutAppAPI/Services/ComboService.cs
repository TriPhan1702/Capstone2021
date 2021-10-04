﻿using System;
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

        public async Task<ActionResult<int>> CreateCombo(CreateComboDTO createComboDTO)
        {
            //Check if status is valid
            if (!GlobalVariables.ComboStatuses.Contains(createComboDTO.Status))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,
                    "Combo Status invalid, must be: " + string.Join(", ", GlobalVariables.ComboStatuses));
            }
            
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
                await _repositoryWrapper.SaveAllAsync();
            }
            catch (Exception e)
            {
                //clear pending changes if fail
                _repositoryWrapper.DeleteChanges();
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError,
                    "Some thing went wrong went creating ComboDetail for Combo");
            }
            
            return new OkObjectResult(result.Id);
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
    }
}