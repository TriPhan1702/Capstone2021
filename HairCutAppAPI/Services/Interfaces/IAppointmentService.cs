using System.Threading.Tasks;
using HairCutAppAPI.DTOs.AppointmentDTOs;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<ActionResult<CustomHttpCodeResponse>> CreateAppointment(CreateAppointmentDTO createAppointmentDTO);
        
        Task<ActionResult<CustomHttpCodeResponse>> CancelAppointment(int appointmentId);

        Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentDetail(int appointmentId);
    }
}