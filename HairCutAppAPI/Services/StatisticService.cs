using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.StatisticDTOs;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public StatisticService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> GetTotalCustomerBySalon(int salonId)
        {
            return new CustomHttpCodeResponse(200,"", await _repositoryWrapper.Appointment.GetTotalCustomerBySalon(salonId));
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetTotalEarningInMonth(string date)
        {
            var dateTime = DateTime.ParseExact(date, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            
            return new CustomHttpCodeResponse(200,"", await _repositoryWrapper.Appointment.GetTotalEarningInMonth(dateTime.Month, dateTime.Year));
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> GetTotalEarningInDay(string date)
        {
            var dateTime = DateTime.ParseExact(date, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            
            return new CustomHttpCodeResponse(200,"", await _repositoryWrapper.Appointment.GetTotalEarningInDay(dateTime));
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> GetEarningInMonthBySalon(GetEarningInMonthBySalonDTO dto)
        {
            await SalonExists(dto.SalonId);
            
            var dateTime = DateTime.ParseExact(dto.Date, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            
            return new CustomHttpCodeResponse(200,"", await _repositoryWrapper.Appointment.GetEarningInMonthBySalon(dateTime.Month, dateTime.Year, dto.SalonId));
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> GetEarningInMonthByCustomer(GetEarningInMonthByCustomerDTO dto)
        {
            await CustomerExists(dto.CustomerUserId);
            
            var dateTime = DateTime.ParseExact(dto.Date, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            
            return new CustomHttpCodeResponse(200,"", await _repositoryWrapper.Appointment.GetTotalEarningInMonthByCustomer(dateTime.Month, dateTime.Year, dto.CustomerUserId));
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> GetEarningInDayBySalon(GetEarningInDayBySalonDTO dto)
        {
            await SalonExists(dto.SalonId);
            
            var dateTime = DateTime.ParseExact(dto.Date, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            
            return new CustomHttpCodeResponse(200,"", await _repositoryWrapper.Appointment.GetTotalEarningInDayBySalon(dateTime, dto.SalonId));
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentStatusStatInMonth(string date)
        {
            var dateTime = DateTime.ParseExact(date, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            var pendingAppointments =
                await _repositoryWrapper.Appointment.GetTotalAppointmentByStatusInMonth(dateTime.Month, dateTime.Year,
                    GlobalVariables.PendingAppointmentStatus);
            var approvedAppointments =
                await _repositoryWrapper.Appointment.GetTotalAppointmentByStatusInMonth(dateTime.Month, dateTime.Year,
                    GlobalVariables.ApprovedAppointmentStatus);
            var ongoingAppointments =
                await _repositoryWrapper.Appointment.GetTotalAppointmentByStatusInMonth(dateTime.Month, dateTime.Year,
                    GlobalVariables.OnGoingAppointmentStatus);
            var canceledAppointments =
                await _repositoryWrapper.Appointment.GetTotalAppointmentByStatusInMonth(dateTime.Month, dateTime.Year,
                    GlobalVariables.CanceledAppointmentStatus);
            var totalAppointment =
                await _repositoryWrapper.Appointment.GetTotalAppointmentInMonth(dateTime.Month, dateTime.Year);
            
            return new CustomHttpCodeResponse(200,"", new GetAppointmentStatusStatResponseDTO()
            {
                PendingAppointments = pendingAppointments,
                ApprovedAppointments = approvedAppointments,
                OnGoingAppointments = ongoingAppointments,
                CancelAppointments = canceledAppointments,
                TotalAppointments = totalAppointment,
            });
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentStatusStatInMonthBySalon(GetAppointmentStatusStatInMonthBySalonDTO dto)
        {
            await SalonExists(dto.SalonId);
            var dateTime = DateTime.ParseExact(dto.Date, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            var pendingAppointments =
                await _repositoryWrapper.Appointment.GetAppointmentByStatusInMonthBySalon(dateTime.Month, dateTime.Year,
                    GlobalVariables.PendingAppointmentStatus, dto.SalonId);
            var approvedAppointments =
                await _repositoryWrapper.Appointment.GetAppointmentByStatusInMonthBySalon(dateTime.Month, dateTime.Year,
                    GlobalVariables.ApprovedAppointmentStatus, dto.SalonId);
            var ongoingAppointments =
                await _repositoryWrapper.Appointment.GetAppointmentByStatusInMonthBySalon(dateTime.Month, dateTime.Year,
                    GlobalVariables.OnGoingAppointmentStatus, dto.SalonId);
            var canceledAppointments =
                await _repositoryWrapper.Appointment.GetAppointmentByStatusInMonthBySalon(dateTime.Month, dateTime.Year,
                    GlobalVariables.CanceledAppointmentStatus, dto.SalonId);
            var totalAppointment =
                await _repositoryWrapper.Appointment.GetAppointmentInMonthBySalon(dateTime.Month, dateTime.Year, dto.SalonId);
            
            return new CustomHttpCodeResponse(200,"", new GetAppointmentStatusStatResponseDTO()
            {
                PendingAppointments = pendingAppointments,
                ApprovedAppointments = approvedAppointments,
                OnGoingAppointments = ongoingAppointments,
                CancelAppointments = canceledAppointments,
                TotalAppointments = totalAppointment,
            });
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentStatusStatInDayBySalon(GetAppointmentStatusStatInDayBySalonDTO dto)
        {
            await SalonExists(dto.SalonId);
            var dateTime = DateTime.ParseExact(dto.Date, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            var pendingAppointments =
                await _repositoryWrapper.Appointment.GetAppointmentByStatusInDayBySalon(dateTime,
                    GlobalVariables.PendingAppointmentStatus, dto.SalonId);
            var approvedAppointments =
                await _repositoryWrapper.Appointment.GetAppointmentByStatusInDayBySalon(dateTime,
                    GlobalVariables.ApprovedAppointmentStatus, dto.SalonId);
            var ongoingAppointments =
                await _repositoryWrapper.Appointment.GetAppointmentByStatusInDayBySalon(dateTime,
                    GlobalVariables.OnGoingAppointmentStatus, dto.SalonId);
            var canceledAppointments =
                await _repositoryWrapper.Appointment.GetAppointmentByStatusInDayBySalon(dateTime,
                    GlobalVariables.CanceledAppointmentStatus, dto.SalonId);
            var totalAppointment =
                await _repositoryWrapper.Appointment.GetAppointmentInDayBySalon(dateTime, dto.SalonId);
            
            return new CustomHttpCodeResponse(200,"", new GetAppointmentStatusStatResponseDTO()
            {
                PendingAppointments = pendingAppointments,
                ApprovedAppointments = approvedAppointments,
                OnGoingAppointments = ongoingAppointments,
                CancelAppointments = canceledAppointments,
                TotalAppointments = totalAppointment,
            });
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentStatusStatInMonthByStaff(GetAppointmentStatusStatInMonthByStaffDTO dto)
        {
            await StaffExists(dto.StaffUserId);
            var dateTime = DateTime.ParseExact(dto.Date, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            var pendingAppointments =
                await _repositoryWrapper.Appointment.GetAppointmentByStatusInMonthByStaff(dateTime.Month, dateTime.Year,
                    GlobalVariables.PendingAppointmentStatus, dto.StaffUserId);
            var approvedAppointments =
                await _repositoryWrapper.Appointment.GetAppointmentByStatusInMonthByStaff(dateTime.Month, dateTime.Year,
                    GlobalVariables.ApprovedAppointmentStatus, dto.StaffUserId);
            var ongoingAppointments =
                await _repositoryWrapper.Appointment.GetAppointmentByStatusInMonthByStaff(dateTime.Month, dateTime.Year,
                    GlobalVariables.OnGoingAppointmentStatus, dto.StaffUserId);
            var canceledAppointments =
                await _repositoryWrapper.Appointment.GetAppointmentByStatusInMonthByStaff(dateTime.Month, dateTime.Year,
                    GlobalVariables.CanceledAppointmentStatus, dto.StaffUserId);
            var totalAppointment =
                await _repositoryWrapper.Appointment.GetAppointmentInMonthByStaff(dateTime.Month, dateTime.Year, dto.StaffUserId);
            
            return new CustomHttpCodeResponse(200,"", new GetAppointmentStatusStatResponseDTO()
            {
                PendingAppointments = pendingAppointments,
                ApprovedAppointments = approvedAppointments,
                OnGoingAppointments = ongoingAppointments,
                CancelAppointments = canceledAppointments,
                TotalAppointments = totalAppointment,
            });
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> GetAppointmentStatusStatInMonthByCustomer(GetAppointmentStatusStatInMonthByCustomerDTO dto)
        {
            await StaffExists(dto.CustomerUserId);
            var dateTime = DateTime.ParseExact(dto.Date, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            var pendingAppointments =
                await _repositoryWrapper.Appointment.GetAppointmentByStatusInMonthByCustomer(dateTime.Month, dateTime.Year,
                    GlobalVariables.PendingAppointmentStatus, dto.CustomerUserId);
            var approvedAppointments =
                await _repositoryWrapper.Appointment.GetAppointmentByStatusInMonthByCustomer(dateTime.Month, dateTime.Year,
                    GlobalVariables.ApprovedAppointmentStatus, dto.CustomerUserId);
            var ongoingAppointments =
                await _repositoryWrapper.Appointment.GetAppointmentByStatusInMonthByCustomer(dateTime.Month, dateTime.Year,
                    GlobalVariables.OnGoingAppointmentStatus, dto.CustomerUserId);
            var canceledAppointments =
                await _repositoryWrapper.Appointment.GetAppointmentByStatusInMonthByCustomer(dateTime.Month, dateTime.Year,
                    GlobalVariables.CanceledAppointmentStatus, dto.CustomerUserId);
            var totalAppointment =
                await _repositoryWrapper.Appointment.GetAppointmentInMonthByCustomer(dateTime.Month, dateTime.Year, dto.CustomerUserId);
            
            return new CustomHttpCodeResponse(200,"", new GetAppointmentStatusStatResponseDTO()
            {
                PendingAppointments = pendingAppointments,
                ApprovedAppointments = approvedAppointments,
                OnGoingAppointments = ongoingAppointments,
                CancelAppointments = canceledAppointments,
                TotalAppointments = totalAppointment,
            });
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> GetCombosUsage()
        {
            var combos = await _repositoryWrapper.Combo.GetAllCombos();
            var result = new List<ComboUsageResponseDTO>();
            foreach (var combo in combos)
            {
                result.Add(new ComboUsageResponseDTO()
                {
                    Id = combo.Id,
                    Name = combo.Name,
                    TimesUsed = await _repositoryWrapper.Appointment.CountComboUsage(combo.Id)
                });
            }
            
            return new CustomHttpCodeResponse(200,"",result);
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> GetSalonsCustomerCount()
        {
            var salons = await _repositoryWrapper.Salon.GetAllSalons();
            var result = new List<SalonCustomerCountResponseDTO>();
            foreach (var salon in salons)
            {
                result.Add(new SalonCustomerCountResponseDTO()
                {
                    Id = salon.Id,
                    Name = salon.Name,
                    CustomerCount = await _repositoryWrapper.Appointment.CountCustomerBySalon(salon.Id)
                });
            }
            
            return new CustomHttpCodeResponse(200,"",result);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetEarningByEachSalonInDay(string date)
        {
            var dateTime = DateTime.ParseExact(date, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);

            var salons = await _repositoryWrapper.Salon.GetAllSalons();
            
            var result = new List<GetEarningInDayBySalonResponseDTO>();

            foreach (var salon in salons)
            {
                result.Add(new GetEarningInDayBySalonResponseDTO()
                {
                    Id = salon.Id,
                    Name = salon.Name,
                    Amount = await _repositoryWrapper.Appointment.GetTotalEarningInDayBySalon(dateTime, salon.Id)
                });
            }
            
            return new CustomHttpCodeResponse(200,"",result);
        }

        private async Task SalonExists(int salonId)
        {
            if (!await _repositoryWrapper.Salon.AnyAsync(salon => salon.Id == salonId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Không tìm thấy Salon");
            }
        }
        
        private async Task StaffExists(int staffUserId)
        {
            if (!await _repositoryWrapper.Staff.AnyAsync(staff => staff.UserId == staffUserId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Không tìm thấy Staff");
            }
        }
        
        private async Task CustomerExists(int customerUserId)
        {
            if (!await _repositoryWrapper.Customer.AnyAsync(customer => customer.UserId == customerUserId))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Không tìm thấy Customer");
            }
        }
    }
}