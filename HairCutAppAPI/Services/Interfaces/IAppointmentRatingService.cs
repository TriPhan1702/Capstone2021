using System.Threading.Tasks;
using HairCutAppAPI.DTOs.AppointmentRatingDTOs;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IAppointmentRatingService
    {
        Task<ActionResult<CustomHttpCodeResponse>> CreateAppointmentRating(CreateAppointmentRatingDTO dto);
    }
}