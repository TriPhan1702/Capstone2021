using System.Threading.Tasks;
using HairCutAppAPI.DTOs.AppointmentDTOs;
using HairCutAppAPI.DTOs.AppointmentRatingDTOs;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class AppointmentRatingController : BaseApiController
    {
        private readonly IAppointmentRatingService _appointmentRatingService;

        public AppointmentRatingController(IAppointmentRatingService appointmentRatingService)
        {
            _appointmentRatingService = appointmentRatingService;
        }
        /// <summary>
        /// For admin, manager and staff
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("advanced_get_ratings")]
        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetRatings(
            AdvancedGetAppointmentRatingDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as AdvancedGetAppointmentRatingDTO;
            var ratings = await _appointmentRatingService.AdvancedGetRatings(dto);
            return ratings;
        }
        
        /// <summary>
        /// Cho Khách Hàng đánh giá appointment đã qua
        /// </summary>
        /// <param name="dto">Stylist Id can be null, StylistId<0 => null</param>
        [Authorize(Roles = GlobalVariables.CustomerRole)]
        [HttpPost("create_appointment")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CreateAppointmentRating([FromBody] CreateAppointmentRatingDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as CreateAppointmentRatingDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
        
            return await _appointmentRatingService.CreateAppointmentRating(dto);
        }
    }
}