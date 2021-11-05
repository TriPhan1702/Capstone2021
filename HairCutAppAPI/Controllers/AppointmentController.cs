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
        /// DEBUG get all appointments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAllAppointments()
        {
            return await _appointmentService.GetAppAppointments();
        }
        
        /// <summary>
        /// for registered users to get list of all statuses that an appointment can have
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("all_appointment_statuses")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAllAppointmentStatuses()
        {
            return await _appointmentService.GetAllAppointmentStatuses();
        }
        
        /// <summary>
        /// Get detail about an appointment
        /// </summary>
        /// <param name="id">Appointment Id</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentDetail(int id)
        {
            return await _appointmentService.GetAppointmentDetail(id);
        }
        
        /// <summary>
        /// For Current customer to check if they have any completed Appointment
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = GlobalVariables.CustomerRole)]
        [HttpGet("check_has_completed_appointment")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CheckCustomerHasCompletedAppointment()
        {
            return await _appointmentService.CheckCustomerHasCompletedAppointment();
        }
        
        /// <summary>
        /// For admin, manager and staff
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("advanced_get_appointments")]
        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetAppointments(
            AdvancedGetAppointmentsDTO advancedGetAppointmentsDTO)
        {
            //Trim All Strings in object
            advancedGetAppointmentsDTO = ObjectTrimmer.TrimObject(advancedGetAppointmentsDTO) as AdvancedGetAppointmentsDTO;
            var appointments = await _appointmentService.AdvancedGetAppointments(advancedGetAppointmentsDTO);
            return appointments;
        }
        
        /// <summary>
        /// For customer to view appointment history
        /// </summary>
        [Authorize]
        [HttpPost("customer_advanced_get_appointments")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CustomerAdvancedGetAppointments(
            CustomerAdvancedGetAppointmentDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as CustomerAdvancedGetAppointmentDTO;
            var appointments = await _appointmentService.CustomerAdvancedGetAppointments(dto);
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
        /// For manager to assign staff to appointment
        /// </summary>
        /// <param name="assignStaffDTO">Stylist Id can be null, StylistId<0 => null</param>
        [Authorize(Roles = GlobalVariables.ManagerRole)]
        [HttpPost("assign_appointment_staff_test")]
        public async Task<ActionResult<CustomHttpCodeResponse>> AssignStaffToAppointmentTest([FromBody] AssignStaffDTO assignStaffDTO)
        {
            //Trim All Strings in object
            assignStaffDTO = ObjectTrimmer.TrimObject(assignStaffDTO) as AssignStaffDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }

            return await _appointmentService.AssignStaff2(assignStaffDTO);
        }
        
        /// <summary>
        /// For Manager, Admin, Staff to finish an appointment
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("finish_appointment")]
        public async Task<ActionResult<CustomHttpCodeResponse>> FinishAppointment([FromForm] FinishAppointmentDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as FinishAppointmentDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }

            return await _appointmentService.FinishAppointment(dto);
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