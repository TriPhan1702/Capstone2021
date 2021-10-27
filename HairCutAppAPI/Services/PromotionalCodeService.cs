using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.PromotionalCodeDTOs;
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
    }
}