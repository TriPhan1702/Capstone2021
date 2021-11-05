using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.DTOs.AppointmentDTOs;
using HairCutAppAPI.DTOs.ComboDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        private readonly HDBContext _hdbContext;

        public AppointmentRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }

        public async Task<Appointment> GetLatestAppointmentOfCustomer(int customerId)
        {
            return await _hdbContext.Appointments.Include(a=>a.AppointmentDetails).Include(a=>a.Customer).Include(a=>a.Salon).OrderByDescending(a => a.CreatedDate)
                .FirstOrDefaultAsync(a => a.CustomerId == customerId);
        }

        public async Task<Appointment> GetAllAppointmentDetail(int appointmentId)
        {
            return await _hdbContext.Appointments.Include(appointment => appointment.Customer)
                .Include(appointment => appointment.Rating)
                .Include(appointment => appointment.Salon)
                .Include(appointment => appointment.AppointmentDetails)
                .ThenInclude(detail => detail.Staff)
                .Include(appointment => appointment.Combo)
                .FirstOrDefaultAsync(a => a.Id == appointmentId);
        }
        
        public async Task<Appointment> GetAllAppointmentWithCustomerAndSalonAndComboAndRating(int appointmentId)
        {
            return await _hdbContext.Appointments.Include(appointment => appointment.Customer)
                .Include(appointment => appointment.Rating)
                .Include(appointment => appointment.Salon)
                .Include(appointment => appointment.Combo)
                .FirstOrDefaultAsync(a => a.Id == appointmentId);
        }

        public async Task<Appointment> GetAppointmentWithDetail(int appointmentId)
        {
            return await _hdbContext.Appointments.Include(a => a.AppointmentDetails)
                .FirstOrDefaultAsync(a => a.Id == appointmentId);
        }

        public async Task<Appointment> GetAppointmentWithDetailAndStaff(int appointmentId)
        {
            return await _hdbContext.Appointments.Include(a => a.AppointmentDetails).ThenInclude(detail => detail.Staff)
                .FirstOrDefaultAsync(a => a.Id == appointmentId);
        }
 
        public async Task<PagedList<AdvancedGetAppointmentsResponseDTO>> AdvancedGetAppointments(AdvancedGetAppointmentsDTO advancedGetAppointmentsDTO)
        {
            var query = _hdbContext.Appointments.Include(appointment => appointment.Customer)
                .Include(appointment => appointment.Salon)
                .Include(appointment => appointment.Combo)
                .AsQueryable();
            
            //If there's status filtering
            if (advancedGetAppointmentsDTO.Statuses != null && advancedGetAppointmentsDTO.Statuses.Any())
            {
                query = query.Where(appointment =>
                    advancedGetAppointmentsDTO.Statuses.Select(status => status.ToLower()).Contains(appointment.Status.ToLower()));
            }
            
            //If There's UserId Filtering
            if (advancedGetAppointmentsDTO.CustomerUserIds != null && advancedGetAppointmentsDTO.CustomerUserIds.Any())
            {
                query = query.Where(appointment => advancedGetAppointmentsDTO.CustomerUserIds.Contains(appointment.Customer.UserId));
            }
            
            //If There's CustomerId Filtering
            if (advancedGetAppointmentsDTO.CustomerIds != null && advancedGetAppointmentsDTO.CustomerIds.Any())
            {
                query = query.Where(appointment => advancedGetAppointmentsDTO.CustomerIds.Contains(appointment.Customer.Id));
            }

            //If There's Customer Name Filtering
            if (!string.IsNullOrWhiteSpace(advancedGetAppointmentsDTO.CustomerName))
            {
                query = query.Where(appointment => appointment.Customer.FullName.ToLower().Contains(advancedGetAppointmentsDTO.CustomerName.ToLower()));
            }
            
            //If There's Combo Name Filtering
            if (!string.IsNullOrWhiteSpace(advancedGetAppointmentsDTO.ComboName))
            {
                query = query.Where(appointment => appointment.Combo.Name.ToLower().Contains(advancedGetAppointmentsDTO.ComboName.ToLower()));
            }
            
            //If There's Salon Name Filtering
            if (!string.IsNullOrWhiteSpace(advancedGetAppointmentsDTO.SalonName))
            {
                query = query.Where(appointment => appointment.Salon.Name.ToLower().Contains(advancedGetAppointmentsDTO.SalonName.ToLower()));
            }
            
            //If there's min price filtering
            // if (advancedGetAppointmentsDTO.MinTotalPrice >= 0)
            // {
            //     query = query.Where(appointment => appointment.Combo.Price >= advancedGetAppointmentsDTO.MinTotalPrice);
            // }
            
            //If there's max price filtering
            // if (advancedGetAppointmentsDTO.MaxTotalPrice >= 0)
            // {
            //     query = query.Where(appointment => appointment.Combo.Price <= advancedGetAppointmentsDTO.MaxTotalPrice);
            // }

            try
            {
                //If there's CreatedDate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetAppointmentsDTO.MinCreatedDate))
                {
                    var date = DateTime.ParseExact(advancedGetAppointmentsDTO.MinCreatedDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(combo => combo.CreatedDate >= date);
                }

                //If there's CreatedDate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetAppointmentsDTO.MaxCreatedDate))
                {
                    var date = DateTime.ParseExact(advancedGetAppointmentsDTO.MaxCreatedDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(combo => combo.CreatedDate <= date);
                }

                //If there's LastUpdate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetAppointmentsDTO.MinLastUpdate))
                {
                        var date = DateTime.ParseExact(advancedGetAppointmentsDTO.MinLastUpdate,
                            GlobalVariables.DateTimeFormat,
                            CultureInfo.InvariantCulture);
                        query = query.Where(combo => combo.LastUpdated >= date);
                }
                
                //If there's LastUpdate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetAppointmentsDTO.MaxLastUpdate))
                {
                    var date = DateTime.ParseExact(advancedGetAppointmentsDTO.MaxLastUpdate,
                        GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(combo => combo.LastUpdated <= date);
                }
                
                //If there's MinDate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetAppointmentsDTO.MinDate))
                {
                    var date = DateTime.ParseExact(advancedGetAppointmentsDTO.MinDate,
                        GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(appointment => appointment.StartDate >= date);
                }
                
                //If there's MaxDate Filtering
                if (!string.IsNullOrWhiteSpace(advancedGetAppointmentsDTO.MaxDate))
                {
                    var date = DateTime.ParseExact(advancedGetAppointmentsDTO.MaxDate,
                        GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(appointment => appointment.EndDate <= date);
                }
            }
            catch (FormatException)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, GlobalVariables.DateTimeFormat);
            }


            //If there's sorting
            if (!string.IsNullOrWhiteSpace(advancedGetAppointmentsDTO.SortBy))
            {
                query = advancedGetAppointmentsDTO.SortBy switch
                {
                    "appointmentid_asc" => query.OrderBy(appointment => appointment.Id),
                    "appointmentid_desc" => query.OrderByDescending(appointment => appointment.Id),
                    "customeruserid_asc" => query.OrderBy(appointment => appointment.Customer.UserId),
                    "customeruserid_desc" => query.OrderByDescending(appointment => appointment.Customer.UserId),
                    "customerid_asc" => query.OrderBy(appointment => appointment.CustomerId),
                    "customerid_desc" => query.OrderByDescending(appointment => appointment.CustomerId),
                    "comboid_asc" => query.OrderBy(appointment => appointment.ComboId),
                    "comboid_desc" => query.OrderByDescending(appointment => appointment.ComboId),
                    "salonid_asc" => query.OrderBy(appointment => appointment.SalonId),
                    "salonid_desc" => query.OrderByDescending(appointment => appointment.SalonId),
                    "customername_asc" => query.OrderBy(appointment => appointment.Customer.FullName),
                    "customername_desc" => query.OrderByDescending(appointment => appointment.Customer.FullName),
                    "comboidname_asc" => query.OrderBy(appointment => appointment.Combo.Name),
                    "comboidname_desc" => query.OrderByDescending(appointment => appointment.Combo.Name),
                    "salonname_asc" => query.OrderBy(appointment => appointment.Combo.Name),
                    "salonname_desc" => query.OrderByDescending(appointment => appointment.Combo.Name),
                    "status_asc" => query.OrderBy(appointment => appointment.Status),
                    "status_desc" => query.OrderByDescending(appointment => appointment.Status),
                    // "toalprice_asc" => query.OrderBy(appointment => appointment.Combo.Price),
                    // "totalprice_desc" => query.OrderByDescending(appointment => appointment.Combo.Price),
                    "createddate_asc" => query.OrderBy(appointment => appointment.CreatedDate),
                    "createddate_desc" => query.OrderByDescending(appointment => appointment.CreatedDate),
                    "lastupdate_asc" => query.OrderBy(appointment => appointment.LastUpdated),
                    "lastupdate_desc" => query.OrderByDescending(appointment => appointment.LastUpdated),
                    "enddate_asc" => query.OrderBy(appointment => appointment.EndDate),
                    "enddate_desc" => query.OrderByDescending(appointment => appointment.EndDate),
                    "startdate_asc" => query.OrderBy(appointment => appointment.EndDate),
                    "startdate_desc" => query.OrderByDescending(appointment => appointment.EndDate),
                    _ => query
                };
            }

            return await PagedList<AdvancedGetAppointmentsResponseDTO>.CreateAsync(
                query.Select(appointment => appointment.ToAdvancedGetAppointmentsResponseDTO()), advancedGetAppointmentsDTO.PageNumber,
                advancedGetAppointmentsDTO.PageSize);
        }

        public async Task<Appointment> GetAppointmentWithComboDetail(int appointmentId)
        {
            return await _hdbContext.Appointments.Include(appointment => appointment.Combo).ThenInclude(combo => combo.ComboDetails).ThenInclude(detail => detail.Service)
                .FirstOrDefaultAsync(a => a.Id == appointmentId);
        }
    }
}