﻿using System.Threading.Tasks;
using HairCutAppAPI.DTOs.AppointmentDTOs;
using HairCutAppAPI.DTOs.CrewDTOs;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<ActionResult<CustomHttpCodeResponse>> CreateAppointment(CreateAppointmentDTO createAppointmentDTO);
        
        Task<ActionResult<CustomHttpCodeResponse>> CancelAppointment(int appointmentId);

        Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentDetail(int appointmentId);
        
        // Task<CustomHttpCodeResponse> AssignCrew(AssignCrewDTO assignCrewDTO);
        
        Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetAppointments(AdvancedGetAppointmentsDTO advancedGetAppointmentsDTO);
    }
}