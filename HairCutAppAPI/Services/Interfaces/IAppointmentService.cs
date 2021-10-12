using System.Threading.Tasks;
using HairCutAppAPI.DTOs.AppointmentDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<ActionResult<CreateAppointmentResponseDTO>> CreateAppointment(CreateAppointmentDTO createAppointmentDTO);
        
        Task<ActionResult<ChangeAppointmentStatusResponseDTO>> CancelAppointment(int appointmentId);
    }
}