﻿using System.Threading.Tasks;
using HairCutAppAPI.DTOs.StatisticDTOs;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IStatisticService
    {
        Task<ActionResult<CustomHttpCodeResponse>> GetTotalEarningInMonth(string date);
        Task<ActionResult<CustomHttpCodeResponse>> GetTotalEarningInDay(string date);
        Task<ActionResult<CustomHttpCodeResponse>> GetEarningInMonthBySalon(GetEarningInMonthBySalonDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> GetEarningInDayBySalon(GetEarningInDayBySalonDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentStatusStatInMonth(string date);
        Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentStatusStatInMonthBySalon(
            GetAppointmentStatusStatInMonthBySalonDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentStatusStatInMonthByStaff(
            GetAppointmentStatusStatInMonthByStaffDTO dto);
    }
}