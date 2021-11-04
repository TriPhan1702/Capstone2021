﻿using System.Threading.Tasks;
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
        
        Task<CustomHttpCodeResponse> AssignStaff(AssignStaffDTO assignCrewDTO);

        Task<ActionResult<CustomHttpCodeResponse>> FinishAppointment(FinishAppointmentDTO dto);
        
        Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetAppointments(AdvancedGetAppointmentsDTO advancedGetAppointmentsDTO);

        Task<ActionResult<CustomHttpCodeResponse>> CustomerAdvancedGetAppointments(
            CustomerAdvancedGetAppointmentDTO dto);

        Task<ActionResult<CustomHttpCodeResponse>> CheckCustomerHasCompletedAppointment();
    }
}