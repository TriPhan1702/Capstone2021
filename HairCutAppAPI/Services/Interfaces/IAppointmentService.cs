using System.Threading.Tasks;
using HairCutAppAPI.DTOs.AppoinmentDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<ActionResult<CreateAppointmentResponseDTO>> CreateAppointment(CreateAppointmentDTO createAppointmentDTO);
    }
}