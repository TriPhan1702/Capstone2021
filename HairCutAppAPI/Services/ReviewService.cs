using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ReviewDTOs;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReviewService(IRepositoryWrapper repositoryWrapper, IHttpContextAccessor httpContextAccessor)
        {
            _repositoryWrapper = repositoryWrapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CreateReview(CreateReviewDTO dto)
        {
            var salon = await _repositoryWrapper.Salon.FindSingleByConditionAsync(sal =>
                sal.Id == dto.SalonId);
            if (salon is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Salon with id {dto.SalonId} not found");
            }

            if (salon.Status == GlobalVariables.ActiveSalonStatus)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Salon with id {dto.SalonId} is not active");
            }

            var customerId = GetCurrentUserId();
            var customer = await _repositoryWrapper.Customer.GetCustomerDetailFromUserId(customerId);
            if (customer is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Customer with id {customerId} not found");
            }

            if (customer.User.Status == GlobalVariables.InActiveUserStatus)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Customer's account is not active");
            }
            
            //Check if there's already the same review
            if (await _repositoryWrapper.Review.AnyAsync(review => review.SalonId == dto.SalonId && review.AuthorId == customerId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Customer has already made a review for this salon");
            }

            //Check if customer has any completed appointment
            if (!await _repositoryWrapper.Appointment.AnyAsync(appointment =>
                appointment.CustomerId == customerId &&
                appointment.Status == GlobalVariables.CompleteAppointmentStatus))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,$"Customer hasn't had any complete appointment");
            }

            var newReview = dto.ToNewReview(customerId);
            var result = await _repositoryWrapper.Review.CreateAsync(newReview);
            return new CustomHttpCodeResponse(200, "Review created", result.ToReviewDTO(salon, customer));
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