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
using HairCutAppAPI.Utilities.ImageUpload;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class ComboService : IComboService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IPhotoService _photoService;

        public ComboService(IRepositoryWrapper repositoryWrapper, IPhotoService photoService)
        {
            _repositoryWrapper = repositoryWrapper;
            _photoService = photoService;
        }

        /// <summary>
        /// DEBUG
        /// </summary>
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAllCombos()
        {
            var combos = await _repositoryWrapper.Combo.FindAllAsync();
            
            return new CustomHttpCodeResponse(200, "", combos);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetComboDetail(int id)
        {
            var combo = await _repositoryWrapper.Combo.GetOneComboWithDetailsAndServiceDetails(id);
            return new CustomHttpCodeResponse(200,"", combo.ToComboDetailDTO());
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
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Không tìm thấy được Com với Id {updateComboDTO.Id}");
            }

            //Upload hình
            // string avatarUrl = null;
            // if (updateComboDTO.AvatarFile != null)
            // {
            //     var imageUploadResult = await _photoService.AppPhotoAsync(updateComboDTO.AvatarFile);
            //     //If there's error
            //     if (imageUploadResult.Error != null)
            //     {
            //         throw new HttpStatusCodeException(HttpStatusCode.BadRequest,imageUploadResult.Error.Message);
            //     }
            //
            //     avatarUrl = imageUploadResult.SecureUrl.AbsoluteUri;
            // }
            
            // If services in DTO is not empty, check and update ComboDetail List
            if (updateComboDTO.Details != null)
            {
                //Check xem có service nào làm bởi stylist chính
                if (!updateComboDTO.Details.Any(detail => detail.IsDoneByStylist))
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Request phải có ít nhất 1 service làm bởi Stylist");
                }
                
                //Check xem order của các service trong dto là đúng
                var currentOrder = 0;
                var orderedDetails = updateComboDTO.Details.OrderBy(detail => detail.ServiceOrder);
                foreach (var detail in orderedDetails)
                {
                    if (detail.ServiceOrder != currentOrder + 1)
                    {
                        throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Service với id {detail.ServiceId} không đúng, thứ tự các service phải là liện tục, bắt đầu từ 1");
                    }
                    currentOrder++;
                }
                
                //Lấy list id các service từ dto
                var serviceIds = updateComboDTO.Details.Select(detail => detail.ServiceId).ToList();
                //Lấy list các service hiện tại của combo
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
                    foreach (var cd in comboDetails.Where(cd => !serviceIds.Contains(cd.Id)))
                    {
                        _repositoryWrapper.ComboDetail.DeleteWithoutSave(cd);
                    }
                }
        
                var addServicesIds = new List<int>();
                //Add new services
                foreach (var serviceId in serviceIds)
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
                        var tempDetailDTO = updateComboDTO.Details.First(detail => detail.ServiceId == serviceId);
                        await _repositoryWrapper.ComboDetail.CreateWithoutSaveAsync(new ComboDetail()
                        {
                            ComboId = updateComboDTO.Id,
                            ServiceId = serviceId,
                            IsDoneByStylist = tempDetailDTO.IsDoneByStylist,
                            ServiceOrder = tempDetailDTO.ServiceOrder
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

        public async Task<ActionResult<CustomHttpCodeResponse>> UploadComboImage(UploadImageDTO dto)
        {
            var combo = await _repositoryWrapper.Combo.FindSingleByConditionAsync(comb => comb.Id == dto.Id);
            if (combo is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Không tìm thấy combo");
            }
            
            var imageUploadResult = await _photoService.AppPhotoAsync(dto.ImageFile);
            //If there's error
            if (imageUploadResult.Error != null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,imageUploadResult.Error.Message);
            }
            
            combo.AvatarUrl = imageUploadResult.SecureUrl.AbsoluteUri;

            var result = await _repositoryWrapper.Combo.UpdateAsync(combo, combo.Id);
            return new CustomHttpCodeResponse(200,"Đã Upload Hình", result.AvatarUrl);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetComboPrice(int id)
        {
            if (!await CheckComboExists(id))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Combo not found");
            }

            return new CustomHttpCodeResponse(200,"", await CalculateComboPrice(id));
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetComboDuration(int id)
        {
            if (!await CheckComboExists(id))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Combo not found");
            }
            
            return new CustomHttpCodeResponse(200,"", await _repositoryWrapper.Combo.CalculateComboDuration(id));
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetAllActiveCombos()
        {
            //Get Active Combo
            var comboDetails = await _repositoryWrapper.Combo.GetActiveCombosWithDetailsAndServiceDetails();
            
            return new CustomHttpCodeResponse(200, "" , comboDetails.Select(c=>c.ToComboDetailDTO()).ToList());
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CreateCombo(CreateComboDTO dto)
        {
            ValidateComboStatus(dto.Status.ToLower());
            ValidateComboPrice(dto.Price);

            //Upload hình
            string avatarUrl = null;
            if (dto.AvatarFile != null)
            {
                var imageUploadResult = await _photoService.AppPhotoAsync(dto.AvatarFile);
                //If there's error
                if (imageUploadResult.Error != null)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,imageUploadResult.Error.Message);
                }

                avatarUrl = imageUploadResult.SecureUrl.AbsoluteUri;
            }
            
            //Prepare new combo
            var newCombo = dto.ToNewCombo(avatarUrl);

            // If services in DTo is not empty, check and prepare ComboDetail List
            // if (dto.Details != null && dto.Details.Any())
            // {
            //     //Check xem trong list có service là bới stylist chính chưa
            //     if (!dto.Details.Any(detail => detail.IsDoneByStylist))
            //     {
            //         throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Trong các service phải có ít nhất 1 service làm bởi stylisr chính");
            //     }
            //     
            //     var comboDetails = await PrepareComboDetail(dto.Details, newCombo);
            //     newCombo.ComboDetails = comboDetails;
            // }

            Combo result;
            try
            {
                result = await _repositoryWrapper.Combo.CreateAsync(newCombo);
            }
            catch (Exception e)
            {
                //clear pending changes if fail
                _repositoryWrapper.DeleteChanges();
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError,
                    "Có lỗi Server khi lưu Combo");
            }
            
            return new CustomHttpCodeResponse(200,"",result.Id);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetCombos(AdvancedGetCombosDTO advancedGetCombosDTO)
        {
            if (!string.IsNullOrWhiteSpace(advancedGetCombosDTO.SortBy) && !AdvancedGetCombosDTO.OrderingParams.Contains(advancedGetCombosDTO.SortBy.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"OrderBy phải là: " + string.Join(", ", AdvancedGetCombosDTO.OrderingParams));
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
        
        private void ValidateComboPrice(decimal price)
        {
            if (price <= 0)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Giá của Combo phải > 0");
            }
        }

        /// <summary>
        /// Prepare a combo's service list to be inserted
        /// </summary>
        private async Task<List<ComboDetail>> PrepareComboDetail(List<CreateUpdateComboDetailDTO> details, Combo combo)
        {
            var currentOrder = 0;
            var orderedDetails = details.OrderBy(detail => detail.ServiceOrder);
            foreach (var detail in orderedDetails)
            {
                if (detail.ServiceOrder != currentOrder + 1)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Service với id {detail.ServiceId} không đúng, thứ tự các service phải là liện tục, bắt đầu từ 1");
                }
                currentOrder++;
            }
            
            var serviceIds = details.Select(detail => detail.ServiceId).ToList();
            //Get Services in dto's service list from Database
            var services =
                (await _repositoryWrapper.Service.FindByConditionAsync(s => serviceIds.Contains(s.Id))).ToList();

            //Check if all Services are valid
            if (services.Count != serviceIds.Count)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Service list của DTO là không đúng");
            }
            
            //Create list of Combo Detail
            return details.Select(detail => new ComboDetail()
            {
                ComboId = combo.Id, 
                ServiceId = detail.ServiceId, 
                IsDoneByStylist = detail.IsDoneByStylist,
                ServiceOrder = detail.ServiceOrder
            }).ToList();
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
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Không tìm thấy được ComboDetail với Id {id}");
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
                    "Combo Status phải là: " + string.Join(", ", GlobalVariables.ComboStatuses));
            }
        }
    }
}