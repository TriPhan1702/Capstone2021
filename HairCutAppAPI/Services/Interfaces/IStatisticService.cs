using System.Threading.Tasks;
using HairCutAppAPI.DTOs.StatisticDTOs;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IStatisticService
    {
        Task<ActionResult<CustomHttpCodeResponse>> GetTotalCustomerBySalon(int salonId);
        Task<ActionResult<CustomHttpCodeResponse>> GetTotalEarningInMonth(string date);
        Task<ActionResult<CustomHttpCodeResponse>> GetTotalEarningInDay(string date);
        Task<ActionResult<CustomHttpCodeResponse>> GetEarningInMonthBySalon(GetEarningInMonthBySalonDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> GetEarningInMonthByCustomer(GetEarningInMonthByCustomerDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> GetEarningInDayBySalon(GetEarningInDayBySalonDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentStatusStatInMonth(string date);
        Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentStatusStatInMonthBySalon(
            GetAppointmentStatusStatInMonthBySalonDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentStatusStatInDayBySalon(
            GetAppointmentStatusStatInDayBySalonDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentStatusStatInMonthByStaff(
            GetAppointmentStatusStatInMonthByStaffDTO dto);

        Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentStatusStatInMonthByCustomer(
            GetAppointmentStatusStatInMonthByCustomerDTO dto);

        Task<ActionResult<CustomHttpCodeResponse>> GetCombosUsage();
        Task<ActionResult<CustomHttpCodeResponse>> GetSalonsCustomerCount();
    }
}