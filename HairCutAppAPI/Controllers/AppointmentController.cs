using System.Threading.Tasks;
using HairCutAppAPI.DTOs.AppoinmentDTOs;
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
        /// For Customer to create appointment
        /// </summary>
        /// <param name="createAppointmentDTO">Stylist Id can be null, StylistId<0 => null</param>
        // [Authorize(Policy = GlobalVariables.RequireCustomerRole)]
        [HttpPost("create_combo")]
        public async Task<ActionResult<CreateAppointmentResponseDTO>> CreateCombo([FromBody] CreateAppointmentDTO createAppointmentDTO)
        {
            //Trim All Strings in object
            createAppointmentDTO = ObjectTrimmer.TrimObject(createAppointmentDTO) as CreateAppointmentDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _appointmentService.CreateAppointment(createAppointmentDTO);
        }
    }
}