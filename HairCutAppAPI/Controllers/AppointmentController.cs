using System.Threading.Tasks;
using HairCutAppAPI.DTOs.AppointmentDTOs;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class AppointmentController : BaseApiController
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        
        /// <summary>
        /// Get detail about an appointment
        /// </summary>
        /// <param name="id">Appointment Id</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetComboPrice(int id)
        {
            return await _appointmentService.GetAppointmentDetail(id);
        }
        
        /// <summary>
        /// For admin, manager and staff
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("advanced_get_appointments")]
        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetWorkSlots(
            AdvancedGetAppointmentsDTO advancedGetAppointmentsDTO)
        {
            //Trim All Strings in object
            advancedGetAppointmentsDTO = ObjectTrimmer.TrimObject(advancedGetAppointmentsDTO) as AdvancedGetAppointmentsDTO;
            var appointments = await _appointmentService.AdvancedGetAppointments(advancedGetAppointmentsDTO);
            return appointments;
        }
        
        /// <summary>
        /// For Customer to create appointment
        /// </summary>
        /// <param name="createAppointmentDTO">Stylist Id can be null, StylistId<0 => null</param>
        [Authorize(Roles = GlobalVariables.CustomerRole)]
        [HttpPost("create_appointment")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CreateAppointment([FromBody] CreateAppointmentDTO createAppointmentDTO)
        {
            //Trim All Strings in object
            createAppointmentDTO = ObjectTrimmer.TrimObject(createAppointmentDTO) as CreateAppointmentDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }

            return await _appointmentService.CreateAppointment(createAppointmentDTO);
        }
        
        /// <summary>
        /// For manager to assign staff to appointment
        /// </summary>
        /// <param name="assignStaffDTO">Stylist Id can be null, StylistId<0 => null</param>
        [Authorize(Roles = GlobalVariables.ManagerRole)]
        [HttpPost("assign_appointment_staff")]
        public async Task<ActionResult<CustomHttpCodeResponse>> AssignStaffToAppointment([FromBody] AssignStaffDTO assignStaffDTO)
        {
            //Trim All Strings in object
            assignStaffDTO = ObjectTrimmer.TrimObject(assignStaffDTO) as AssignStaffDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }

            return await _appointmentService.AssignStaff(assignStaffDTO);
        }

        /// <summary>
        /// Cancel an Appointment
        /// </summary>
        /// <param name="id">Appointment Id</param>
        [Authorize(Roles = GlobalVariables.ManagerRole + ", " + GlobalVariables.AdministratorRole + ", " + GlobalVariables.CustomerRole)]
        [HttpPut("cancel_appointment/{id}")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CancelAppointment(int id)
        {
            return await _appointmentService.CancelAppointment(id);
        }
    }
}