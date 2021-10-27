using System;
using System.Globalization;
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
            if (await _repositoryWrapper.PromotionalCode.AnyAsync(code => code.Code == createPromotionalCodeDTO.Code && code.Status == GlobalVariables.ActivePromotionalCodeStatus))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"");
            }

            var startDate = DateTime.ParseExact(createPromotionalCodeDTO.StartDate, GlobalVariables.DateTimeFormat,
                CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(createPromotionalCodeDTO.ExpirationDate, GlobalVariables.DateTimeFormat,
                CultureInfo.InvariantCulture);
            var newPromotionalCode = createPromotionalCodeDTO.ToPromotionalCode(startDate, endDate);

            var result = await _repositoryWrapper.PromotionalCode.CreateAsync(newPromotionalCode);
            
            return new CustomHttpCodeResponse(200, "Promotional Code Created",result.Id);
        }
    }
}