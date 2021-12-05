﻿using System.Threading.Tasks;
using HairCutAppAPI.DTOs;
using HairCutAppAPI.DTOs.StaffDTOs;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class StaffController : BaseApiController
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        
        /// <summary>
        /// Get staff types
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("get_staff_types")]
        public  ActionResult<CustomHttpCodeResponse> GetStaffTypes()
        {
            return new CustomHttpCodeResponse(200,"", GlobalVariables.StaffTypes);
        }
        
        /// <summary>
        /// Get profile of a staff
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns></returns>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetStaffDetail(int id)
        {
            return await _staffService.GetStaffDetail(id);
        }
        
        /// <summary>
        /// For admin, manager and staff
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("advanced_get_staffs")]
        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetStaffs(
            AdvancedGetStaffDTO advancedGetStaffDTO)
        {
            //Trim All Strings in object
            advancedGetStaffDTO = ObjectTrimmer.TrimObject(advancedGetStaffDTO) as AdvancedGetStaffDTO;
            var staffs = await _staffService.AdvancedGetStaffs(advancedGetStaffDTO);
            return staffs;
        }
        
        /// <summary>
        /// For Admin to create staff
        /// </summary>
        /// <param name="createStaffDTO"></param>
        /// <returns></returns>
        [Authorize(Roles = GlobalVariables.AdministratorRole)]
        [HttpPost("create_staff")]
        public async Task<ActionResult<CustomHttpCodeResponse>> CreateStaff([FromForm] CreateStaffDTO createStaffDTO)
        {
            //Trim All Strings in object
            createStaffDTO = ObjectTrimmer.TrimObject(createStaffDTO) as CreateStaffDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
        
            return await _staffService.CreateStaff(createStaffDTO);
        }
        
        /// <summary>
        /// For Admin to add a staff to salon
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = GlobalVariables.AdministratorRole)]
        [HttpPut("add_staff_to_salon")]
        public async Task<ActionResult<CustomHttpCodeResponse>> AddStaffToSalon([FromBody] ChangeSalonStaffDTO changeSalonStaffDTO)
        {
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }

            return await _staffService.AddStaffToSalon(changeSalonStaffDTO);
        }

        /// <summary>
        /// For Admin To remove staff's salon
        /// </summary>
        /// <param name="id">StaffId</param>
        /// <returns></returns>
        [Authorize(Roles = GlobalVariables.AdministratorRole)]
        [HttpPut("remove_staff_from_salon/{id}")]
        public async Task<ActionResult<CustomHttpCodeResponse>> RemoveStaffFromSalon(int id)
        {
            

            return await _staffService.RemoveStaffFromSalon(id);
        }
        
        /// <summary>
        /// Get list of stylist that have available work slot between start date and end date(dd/MM/yyyy)
        /// </summary>
        [Authorize]
        [HttpPost("get_available_stylists_in_span_of_day")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAvailableStylistsOfASalonInSpanOfDay(
            GetAvailableStylistsOfASalonInSpanOfDayDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as GetAvailableStylistsOfASalonInSpanOfDayDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
            
            return  await _staffService.GetAvailableStylistsOfASalonInSpanOfDay(dto);;
        }
        
        /// <summary>
        /// Get list of stylist in a salon
        /// </summary>
        [Authorize]
        [HttpGet("get_available_stylist_in_salon/{id}")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetStylistListOfSalon(int id)
        {
            
            return  await _staffService.GetStylistListOfSalon(id);;
        }
        
        /// <summary>
        /// Get list of available staff that can perform an appointment
        /// </summary>
        [Authorize(Roles = GlobalVariables.ManagerRole)]
        [HttpGet("get_available_staff_for_appointment/{id}")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAvailableStaffsForAppointment(int id)
        {
            return  await _staffService.GetAvailableStaffsForAppointment(id);;
        }
        
        /// <summary>
        /// For Staff and manager to update their information
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPut("update_staff")]
        public async Task<ActionResult<CustomHttpCodeResponse>> UpdateStaff([FromBody] UpdateStaffDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as UpdateStaffDTO;
            
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
            
            return await _staffService.UpdateStaff(dto);
        }
        
        /// <summary>
        /// For admin to update a staff or manager
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = GlobalVariables.AdministratorRole)]
        [HttpPut("admin_update_staff")]
        public async Task<ActionResult<CustomHttpCodeResponse>> AdministratorUpdateStaff([FromBody] AdministratorUpdateStaffDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as AdministratorUpdateStaffDTO;
            
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
            
            return await _staffService.AdministratorUpdateStaff(dto);
        }
    }
}