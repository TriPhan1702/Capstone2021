using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.PromotionalCodeDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class PromotionalCodeService : IPromotionalCodeService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public PromotionalCodeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CreatePromotionalCode(
            CreatePromotionalCodeDTO createPromotionalCodeDTO)
        {
            //Check if there's an active code already exist
            if (await _repositoryWrapper.PromotionalCode.AnyAsync(code => code.Code == createPromotionalCodeDTO.Code && code.Status == GlobalVariables.ActivePromotionalCodeStatus))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"An active promotional code with the same code already existed");
            }

            //If the code is universal but still have list of salon, abort
            if (createPromotionalCodeDTO.IsUniversal && createPromotionalCodeDTO.SalonIds.Any())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Universal code can't have list of salon ids ");
            }

            var startDate = DateTime.ParseExact(createPromotionalCodeDTO.StartDate, GlobalVariables.DateTimeFormat,
                CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(createPromotionalCodeDTO.ExpirationDate, GlobalVariables.DateTimeFormat,
                CultureInfo.InvariantCulture);
            var newPromotionalCode = createPromotionalCodeDTO.ToPromotionalCode(startDate, endDate);

            var result = await _repositoryWrapper.PromotionalCode.CreateAsync(newPromotionalCode);
            
            return new CustomHttpCodeResponse(200, "Promotional Code Created",result.Id);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetPromotionalCodes(AdvancedGetPromotionalCodesDTO dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.SortBy) && !AdvancedGetPromotionalCodesDTO.OrderingParams.Contains(dto.SortBy.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"OrderBy must be: " + string.Join(", ", AdvancedGetPromotionalCodesDTO.OrderingParams));
            }
            
            var result = await _repositoryWrapper.PromotionalCode.AdvancedGetPromotionalCodes(dto);
            return new CustomHttpCodeResponse(200, "" , result);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> UpdatePromotionalCode(UpdatePromotionalCodeDTO dto)
        {
            //Get promotional code from database
            var code = await _repositoryWrapper.PromotionalCode.GetOnePromotionalWithSalon(dto.Id);
            if (code is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Promotional Code with Id {dto.Id} not found");
            }
            
            code = dto.CompareUpdatePromotionalCode(code);
            
            //If IsUniversal is set to false
            if (dto.IsUniversal == 0)
            {
                //If no salon id is provided and the code doesn't have a list of salon already
                if (!dto.SalonIds.Any() && !code.SalonsCodes.Any())
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Promotional Code is set to be not universal but no Salon list is provided");
                }
                
                var codeSalonIds = code.SalonsCodes.Select(salonsCodes => salonsCodes.SalonId).ToList();
                var deletedSalonIds = dto.SalonIds.Except(codeSalonIds);
                var addedSalonIds = codeSalonIds.Except(dto.SalonIds);

                //Pend delete changes
                foreach (var salonId in deletedSalonIds)
                { 
                    _repositoryWrapper.SalonsCodes.DeleteWithoutSave(
                        code.SalonsCodes.First(codes => codes.SalonId == salonId));
                }
                
                //Pend create changes
                foreach (var salonId in addedSalonIds)
                {
                    await _repositoryWrapper.SalonsCodes.CreateWithoutSaveAsync(new SalonsCodes()
                    {
                        CodeId = code.Id,
                        SalonId = salonId
                    });
                }
            }
            
            var hasChanged = false;
            //If there's changes to start date
            if (!string.IsNullOrWhiteSpace(dto.StartDate))
            {
                var startDate = DateTime.ParseExact(dto.StartDate, GlobalVariables.DayFormat,
                    CultureInfo.InvariantCulture);
                code.StartDate = startDate;
                hasChanged = true;
            }
            
            //If there's changes to end date
            if (!string.IsNullOrWhiteSpace(dto.ExpirationDate))
            {
                var expDate = DateTime.ParseExact(dto.ExpirationDate, GlobalVariables.DayFormat,
                    CultureInfo.InvariantCulture);
                code.ExpirationDate = expDate;
                hasChanged = true;
            }

            if (code.StartDate >= code.ExpirationDate)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Start Date is after ExpirationalDate");
            }

            if (hasChanged)
            {
                code.LastUpdate = DateTime.Now;
            }

            //Pend changes to promotional code table
            await _repositoryWrapper.PromotionalCode.UpdateAsyncWithoutSave(code, code.Id);
            
            try
            {
                //Save all changes above to database 
                await _repositoryWrapper.SaveAllAsync();
            }
            catch (Exception e)
            {
                //clear pending changes if fail
                _repositoryWrapper.DeleteChanges();
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError,
                    "Some thing went wrong when updating Promotional Code " + e.Message);
            }

            //Get the updated code to show
            code = await _repositoryWrapper.PromotionalCode.GetOnePromotionalWithSalon(code.Id);
            
            return new CustomHttpCodeResponse(200, "", code.ToUpdatePromotionalCodeResponseDTO());
        }
    }
}