using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ComboDTOs;
using HairCutAppAPI.DTOs.CrewDTOs;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class CrewController : BaseApiController
    {
        private readonly ICrewService _crewService;

        public CrewController(ICrewService crewService)
        {
            _crewService = crewService;
        }
        
        /// <summary>
        /// For Manager to assign crew to appointment
        /// </summary>
        [Authorize(Policy = GlobalVariables.RequireManagerRole)]
        [HttpPost("assign_crew")]
        public async Task<ActionResult<AssignCrewResponseDTO>> AssignCrew([FromBody] AssignCrewDTO assignCrewDTO)
        {
            //Check input server side
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _crewService.AssignCrew(assignCrewDTO);
        }
    }
}