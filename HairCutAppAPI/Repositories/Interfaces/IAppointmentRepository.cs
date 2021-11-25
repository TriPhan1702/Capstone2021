﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.AppointmentDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        Task<Appointment> GetLatestAppointmentOfCustomer(int customerId);
        Task<Appointment> GetAllAppointmentDetail(int appointmentId);
        Task<Appointment> GetAppointmentWithDetail(int appointmentId);
        Task<Appointment> GetAppointmentWithDetailAndStaff(int appointmentId);
        Task<Appointment> GetAppointmentWithComboDetail(int appointmentId);
        Task<PagedList<AdvancedGetAppointmentsResponseDTO>> AdvancedGetAppointments(AdvancedGetAppointmentsDTO advancedGetAppointmentsDTO);
        Task<Appointment> GetAppointmentWithCustomerDetail(int appointmentId);
        Task<Appointment> GetOneAppointmentWithCustomerAndSalonAndComboAndRatingAndCode(int appointmentId);
        Task<decimal> GetTotalEarningInMonth(int month, int year);
        Task<decimal> GetTotalEarningInDay(DateTime date);
        Task<decimal> GetEarningInMonthBySalon(int month, int year, int salonId);
        Task<decimal> GetTotalEarningInDay(DateTime date, int salonId);
        Task<int> GetTotalAppointmentByStatusInMonth(int month, int year, string status);
        Task<int> GetTotalAppointmentInMonth(int month, int year);
        Task<int> GetAppointmentByStatusInMonthBySalon(int month, int year, string status, int salonId);
        Task<int> GetAppointmentInMonthBySalon(int month, int year, int salonId);
        Task<int> GetAppointmentByStatusInMonthByStaff(int month, int year, string status, int staffUserId);
        Task<int> GetAppointmentInMonthByStaff(int month, int year, int staffUserId);
        Task<List<Appointment>> GetOngoingAppointmentsWithChosenStaffAndCustomer();
    }
}