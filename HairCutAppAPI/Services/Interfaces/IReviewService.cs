using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ReviewDTOs;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IReviewService
    {
        Task<ActionResult<CustomHttpCodeResponse>> CreateReview(CreateReviewDTO dto);
    }
}