﻿using System.Threading.Tasks;
using HairCutAppAPI.DTOs.StatisticDTOs;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Controllers
{
    public class StatisticController : BaseApiController
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }
        
        /// <summary>
        /// Tìm số tiền kiếm đc trong 1 tháng của tất cả salon
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("get_total_earning_in_month")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetTotalEarningInMonth([FromBody]string date)
        {
            return await _statisticService.GetTotalEarningInMonth(date);
        }
        
        /// <summary>
        /// Tìm số tiền kiếm đc trong 1 ngày của tất cả salon
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("get_total_earning_in_day")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetTotalEarningInDay([FromBody]string date)
        {
            return await _statisticService.GetTotalEarningInDay(date);
        }
        
        /// <summary>
        /// Tìm số tiền kiếm đc trong 1 tháng của 1 salon
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("get_earning_in_month_by_salon")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetEarningInMonthBySalon([FromBody]GetEarningInMonthBySalonDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as GetEarningInMonthBySalonDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
            
            return await _statisticService.GetEarningInMonthBySalon(dto);
        }
        
        /// <summary>
        /// Tìm số tiền kiếm khách hàng đã tiêu trong 1 tháng
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("get_earning_in_month_by_customer")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetEarningInMonthByCustomer([FromBody]GetEarningInMonthByCustomerDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as GetEarningInMonthByCustomerDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
            
            return await _statisticService.GetEarningInMonthByCustomer(dto);
        }
        
        /// <summary>
        /// Tìm số tiền kiếm đc trong 1 ngày của 1 salon
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("get_earning_in_day_by_salon")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetEarningInDayBySalon([FromBody]GetEarningInDayBySalonDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as GetEarningInDayBySalonDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
            
            return await _statisticService.GetEarningInDayBySalon(dto);
        }
        
        /// <summary>
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("get_appointment_by_status_in_month")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentByStatusInMonth([FromBody]string date)
        {
            
            return await _statisticService.GetAppointmentStatusStatInMonth(date);
        }
        
        /// <summary>
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("get_appointment_by_status_in_month_by_salon")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentByStatusInMonthBySalon([FromBody]GetAppointmentStatusStatInMonthBySalonDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as GetAppointmentStatusStatInMonthBySalonDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
            return await _statisticService.GetAppointmentStatusStatInMonthBySalon(dto);
        }
        
        /// <summary>
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("get_appointment_by_status_in_month_by_staff")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentStatusStatInMonthByStaff([FromBody]GetAppointmentStatusStatInMonthByStaffDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as GetAppointmentStatusStatInMonthByStaffDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
            return await _statisticService.GetAppointmentStatusStatInMonthByStaff(dto);
        }
        
        /// <summary>
        /// </summary>
        [Authorize(Roles = GlobalVariables.AdministratorRole + ", " + GlobalVariables.ManagerRole + ", " + GlobalVariables.StylistRole + ", " + GlobalVariables.BeauticianRole)]
        [HttpPost("get_appointment_by_status_in_month_by_customer")]
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentStatusStatInMonthByCustomer([FromBody]GetAppointmentStatusStatInMonthByCustomerDTO dto)
        {
            //Trim All Strings in object
            dto = ObjectTrimmer.TrimObject(dto) as GetAppointmentStatusStatInMonthByCustomerDTO;
            
            //Check input server side
            if (!ModelState.IsValid)
            {
                return new CustomHttpCodeResponse(400,"",ModelState);
            }
            return await _statisticService.GetAppointmentStatusStatInMonthByCustomer(dto);
        }
    }
}