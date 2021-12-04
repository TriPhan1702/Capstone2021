using System.Threading.Tasks;
using HairCutAppAPI.DTOs.AppointmentDTOs;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IAppointmentService
    {
        /// <summary>
        /// Debug
        /// </summary>
        Task<ActionResult<CustomHttpCodeResponse>> GetAppAppointments();

        Task<ActionResult<CustomHttpCodeResponse>> GetAllAppointmentStatuses();
        Task<ActionResult<CustomHttpCodeResponse>> CreateAppointment(CreateAppointmentDTO createAppointmentDTO);
        
        Task<ActionResult<CustomHttpCodeResponse>> CancelAppointment(int appointmentId);

        Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentDetail(int appointmentId);
        Task<ActionResult<CustomHttpCodeResponse>> AssignStaff(AssignStaffDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> CheckAppointmentCanBeAssigned(int appointmentId);

        Task<ActionResult<CustomHttpCodeResponse>> StaffFinishAppointment(FinishAppointmentDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> ManagerFinishAppointment(int appointmentId);
        
        Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetAppointments(AdvancedGetAppointmentsDTO advancedGetAppointmentsDTO);
        ActionResult<CustomHttpCodeResponse> GetSortByForAdvancedGetAppointments();

        Task<ActionResult<CustomHttpCodeResponse>> CustomerAdvancedGetAppointments(
            CustomerAdvancedGetAppointmentDTO dto);

        Task<ActionResult<CustomHttpCodeResponse>> CheckCustomerHasCompletedAppointment();
    }
}