using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.PromotionalCodeDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class PromotionalCodeService : IPromotionalCodeService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PromotionalCodeService(IRepositoryWrapper repositoryWrapper, IHttpContextAccessor httpContextAccessor)
        {
            _repositoryWrapper = repositoryWrapper;
            _httpContextAccessor = httpContextAccessor;
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
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Không tìm thấy mã khuyến mãi với Id {dto.Id}");
            }
            
            code = dto.CompareUpdatePromotionalCode(code);

            if (!GlobalVariables.PromotionalCodeStatuses.Contains(dto.Status.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Status của mã khuyến mãi phải là: " + string.Join(", ",GlobalVariables.PromotionalCodeStatuses));
            }
            
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

        public async Task<ActionResult<CustomHttpCodeResponse>> ValidateCodeForAppointment(ValidateCodeForAppointmentDTO dto)
        {
            var currentUserId = GetCurrentUserId();
            var customer = await GetCustomer(currentUserId);
            
            //Tìm code trong database
            var promotionalCode = await GetPromotionalCode(dto.Code);

            //Check status code, nếu đang ko active thì ko đc
            if (promotionalCode.Status != GlobalVariables.ActivePromotionalCodeStatus)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Không sử dụng được Code này");
            }

            var combo = await _repositoryWrapper.Combo.FindSingleByConditionAsync(com => com.Id == dto.SalonId);
            if (combo is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Không tìm thấy Combo với Id {dto.ComboId}");
            }

            //Nếu code này không để dùng chung trong tất cả Salon
            //Check xem salon hợp lệ ko
            if (!promotionalCode.IsUniversal && !await _repositoryWrapper.SalonsCodes.AnyAsync(code => code.SalonId == dto.SalonId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Không sử dụng được Code này");
            }

            //Nếu có set số lần dùng
            if (promotionalCode.UsesPerCustomer > 0)
            {
                var customerCode =
                    await _repositoryWrapper.CustomersCodes.FindSingleByConditionAsync(code =>
                        code.CustomerId == customer.Id);
                //Nếu Customer đã có cùng code và số lần dùng lớn hơn bằng giới hạn
                if (customerCode != null && customerCode.TimesUsed >= promotionalCode.UsesPerCustomer)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Không sử dụng được Code này");
                }
            }

            var payingPrice = decimal.Floor(combo.Price - (combo.Price / 100 * promotionalCode.Percentage));

            return new CustomHttpCodeResponse(200,"Code có thể sủ dụng được", new ValidateCodeForAppointmentResponseDTO()
            {
                PayingPrice = RoundingTo(payingPrice,500)
            });
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetPromotionalCodeDetail(int id)
        {
            var code = await _repositoryWrapper.PromotionalCode.GetOnePromotionalWithSalon(id);
            if (code is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Không tìm thấy code với Id {id}");
            }
            
            return new CustomHttpCodeResponse(200,"", code.ToGetPromotionalCodeDetailResponseDTO());
        }

        #region private functions

        private int GetCurrentUserId()
        {
            int customerId;
            if (_httpContextAccessor.HttpContext == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"No current user is active");
            }

            try
            {
                //Get Current customer Id
                customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            catch (ArgumentNullException e)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Current User Id not Found");
            }

            return customerId;
        }

        private async Task<Customer> GetCustomer(int userId)
        {
            var customer =
                await _repositoryWrapper.Customer.FindSingleByConditionAsync(cus => cus.UserId == userId);
            if (customer is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Không tìm thấy Customer với User Id {userId}");
            }

            return customer;
        }

        private async Task<PromotionalCode> GetPromotionalCode(string code)
        {
            var promotionalCode =
                await _repositoryWrapper.PromotionalCode.FindSingleByConditionAsync(proCode =>
                    proCode.Code.ToLower() == code.ToLower());
            if (promotionalCode is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Không tìm thấy Promotional Code {code}");
            }

            return promotionalCode;
        }
        
        private decimal RoundingTo(decimal myNum, int roundTo)
        {
            myNum = decimal.Floor(myNum);
            if (roundTo <= 0) return myNum;
            return (myNum + roundTo / 2) / roundTo * roundTo;
        }
        
        #endregion private functions
    }
}