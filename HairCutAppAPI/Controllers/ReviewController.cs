using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ReviewDTOs;
using HairCutAppAPI.DTOs.SalonDTOs;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class ReviewController : BaseApiController
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        /// <summary>
        /// For Customer to create review for a salon
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = GlobalVariables.CustomerRole)]
        [HttpPost("create_salon")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CreateReview([FromBody] CreateReviewDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as CreateReviewDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }

            return await _reviewService.CreateReview(dto);
        }
    }
}