using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.AppointmentRatingDTOs;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class AppointmentRatingService : IAppointmentRatingService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppointmentRatingService(IRepositoryWrapper repositoryWrapper, IHttpContextAccessor httpContextAccessor)
        {
            _repositoryWrapper = repositoryWrapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CreateAppointmentRating(CreateAppointmentRatingDTO dto)
        {
            if (dto.Rating < 0 && dto.Rating > 5)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Số điểm phải từ 1 tới 5");
            }
            
            var currentUserId = GetCurrentUserId();

            if (!await _repositoryWrapper.Customer.AnyAsync(customer => customer.UserId == currentUserId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Không tìm thấy customer");
            }

            if (!await _repositoryWrapper.Appointment.AnyAsync(appointment =>
                //Có Id giống
                appointment.Id == dto.AppointmentId && 
                //Appointment là của customer hiện tại
                appointment.Customer.UserId == currentUserId && 
                //Appointment có status là complete
                appointment.Status == GlobalVariables.CompleteAppointmentStatus))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Không tìm appointment đã hoàn thành với Id {dto.AppointmentId} của khách hàng hiện tại");
            }

            var newRating = dto.ToNewAppointmentRating();
            var result = await _repositoryWrapper.AppointmentRating.CreateAsync(newRating);
            
            return new CustomHttpCodeResponse(200,"Appointment rating đã tạo", result.Id);
        }
        
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
    }
}