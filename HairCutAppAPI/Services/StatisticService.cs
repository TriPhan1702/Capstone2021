using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.StatisticDTOs;
using HairCutAppAPI.Entities;
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

        public async Task<ActionResult<CustomHttpCodeResponse>> GetTopCustomers(TopCustomerDTO dto)
        {
            var fromDate = DateTime.ParseExact(dto.FromDate, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            var toDate = DateTime.ParseExact(dto.ToDate, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            var customers = (await _repositoryWrapper.Customer.GetAllCustomersOfSalon(dto.SalonId)).ToList();
            if (!customers.Any())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Customers not found");
            }
            var result = new List<TopCustomerResponseDTO>();
            foreach (var customer in customers)
            {
                var totalAppointment = await _repositoryWrapper.Appointment.CountAsync(appointment =>
                    //Có đúng Customer Id
                    appointment.CustomerId == customer.Id &&
                    //Complete
                    appointment.Status == GlobalVariables.CompleteAppointmentStatus &&
                    appointment.SalonId == dto.SalonId && 
                    appointment.StartDate >= fromDate &&
                    appointment.EndDate <= toDate);
                var totalPayment = await _repositoryWrapper.Appointment.GetCustomerTotalPaymentOfSalonInTimSpan(dto.SalonId, fromDate, toDate, customer.Id);
                
                result.Add(new TopCustomerResponseDTO()
                {
                    Id = customer.Id,
                    UserId = customer.UserId,
                    TotalAppointment = totalAppointment,
                    TotalPayment = totalPayment,
                    FullName = customer.FullName
                });
            }
            
            return new CustomHttpCodeResponse(200,"",result);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetTopStaff(GetTopStaffDTO dto)
        {
            var fromDate = DateTime.ParseExact(dto.FromDate, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            var toDate = DateTime.ParseExact(dto.ToDate, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            List<Staff> staffs;
            //Nếu ko có role
            if (string.IsNullOrWhiteSpace(dto.Role))
            {
                staffs = (await _repositoryWrapper.Staff.FindByConditionAsync(sta => sta.SalonId == dto.SalonId)).ToList();
            }
            else
            {
                if (!GlobalVariables.StaffTypes.Contains(dto.Role))
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Role has to be: stylist, beautician");
                }
                staffs = (await _repositoryWrapper.Staff.FindByConditionAsync(sta => sta.SalonId == dto.SalonId &&
                                                                                    sta.StaffType == dto.Role)).ToList();
            }

            if (!staffs.Any())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Staffs not found");
            }

            var result = new List<GetTopStaffResponseDTO>();
            foreach (var staff in staffs)
            {
                var totalAppointment = await _repositoryWrapper.Appointment.CountAsync(appointment =>
                    appointment.AppointmentDetails.Any(detail => detail.StaffId == staff.Id) &&
                    appointment.Status == GlobalVariables.CompleteAppointmentStatus &&
                    appointment.StartDate >= fromDate && 
                    appointment.EndDate <= toDate &&
                    appointment.SalonId == dto.SalonId
                    );
                result.Add(new GetTopStaffResponseDTO()
                {
                    StaffId = staff.Id,
                    FullName = staff.FullName,
                    StaffType = staff.StaffType,
                    TotalAppointment = totalAppointment,
                    StaffUserId = staff.UserId
                });
            }
            
            return new CustomHttpCodeResponse(200,"",result);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetSalonEarningPerDay(GetSalonEarningPerDayDTO dto)
        {
            var salon = await _repositoryWrapper.Salon.FindSingleByConditionAsync(sal => sal.Id == dto.SalonId);
            if (salon is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Salon not found");
            }
            var fromDate = DateTime.ParseExact(dto.FromDate, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            var toDate = DateTime.ParseExact(dto.ToDate, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            var datesBetween = new List<DateTime>();
            for (var date = fromDate; date <= toDate; date = date.AddDays(1))
            {
                datesBetween.Add(date);
            }
            
            var result = new GetSalonEarningPerDayResponseDTO()
            {
                SalonId = dto.SalonId,
                SalonName = salon.Name,
                DayInfos = new List<GetSalonEarningPerDayResponseDayInfoDTO>()
            };

            foreach (var date in datesBetween)
            {
                var earning = await _repositoryWrapper.Appointment.GetTotalEarningInDayBySalon(date, salon.Id);
                result.DayInfos.Add(new GetSalonEarningPerDayResponseDayInfoDTO()
                {
                    Date = date.ToString(GlobalVariables.DayFormat),
                    TotalEarning = earning
                });
            }
            
            return new CustomHttpCodeResponse(200,"",result);
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> GetTotalAppointmentBySalonInTimeSpan(GetTotalAppointmentBySalonDTO dto)
        {
            var salon = await _repositoryWrapper.Salon.FindSingleByConditionAsync(sal => sal.Id == dto.SalonId);
            if (salon is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Salon not found");
            }
            var fromDate = DateTime.ParseExact(dto.FromDate, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            var toDate = DateTime.ParseExact(dto.ToDate, GlobalVariables.DayFormat, CultureInfo.InvariantCulture);
            var datesBetween = new List<DateTime>();
            for (var date = fromDate; date <= toDate; date = date.AddDays(1))
            {
                datesBetween.Add(date);
            }
            
            var result = new GetTotalAppointmentBySalonResponseDTO()
            {
                SalonId = dto.SalonId,
                SalonName = salon.Name,
                DayInfos = new List<GetTotalAppointmentBySalonResponseDayInfoDTO>()
            };

            foreach (var date in datesBetween)
            {
                var totalAppointment = await _repositoryWrapper.Appointment.CountAsync(appointment => appointment.SalonId == salon.Id && 
                                                                                             appointment.Status == GlobalVariables.CompleteAppointmentStatus && 
                                                                                             appointment.StartDate.DayOfYear == date.DayOfYear && 
                                                                                             appointment.StartDate.Year == date.Year);
                result.DayInfos.Add(new GetTotalAppointmentBySalonResponseDayInfoDTO()
                {
                    Date = date.ToString(GlobalVariables.DayFormat),
                    TotalAppointment = totalAppointment
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