using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.CrewDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;

namespace HairCutAppAPI.Services
{
    public class CrewService : ICrewService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CrewService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<AssignCrewResponseDTO> AssignCrew(AssignCrewDTO assignCrewDTO)
        {
            var appointment = await _repositoryWrapper.Appointment.GetAppointmentWithDetailAndCrewDetail(assignCrewDTO.AppointmentId);
            if (appointment is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Appointment with id {assignCrewDTO.AppointmentId} not found");
            }

            //Check if appointment has pending status
            if (appointment.Status != GlobalVariables.PendingAppointmentStatus)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Appointment is not pending ");
            }

            //If appointment hasn't had a crew yet, create a new crew
            if (appointment.AppointmentDetail.CrewId is null)
            {
                appointment.AppointmentDetail.Crew = new Crew
                {
                    CreatedDate = DateTime.Now, LastUpdated = DateTime.Now, CrewDetails = new List<CrewDetail>()
                };
            }
            
            //If appointment already has a crew, check for duplicate staffs
            else
            {
                var duplicateStaffs =
                    appointment.AppointmentDetail.Crew.CrewDetails.Where(crewDetail => assignCrewDTO.StaffIds.Contains(crewDetail.StaffId)).ToList();
                //If there's Duplicate, remove that staff id from dto
                if (duplicateStaffs.Any())
                {
                    foreach (var staff in duplicateStaffs)
                    {
                        assignCrewDTO.StaffIds.Remove(staff.StaffId);
                    }
                }
            }
            
            //Get All Staff from database that has valid id and is from the same salon as the appointment
            var staffs = await _repositoryWrapper.Staff.FindByConditionAsync(staff =>
                assignCrewDTO.StaffIds.Contains(staff.Id) && staff.SalonId == appointment.SalonId);
            if (staffs is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"No Staff is found");
            }
            //If the count is not the same, then some staff doesn't exist or not from the same salon
            if ( staffs.Count() != assignCrewDTO.StaffIds.Count)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"Some Staff is not found or not from the same salon");
            }

            //Pend Changes to appointment
            foreach (var staffId in assignCrewDTO.StaffIds)
            {
                //Change appointment status
                appointment.Status = GlobalVariables.ApprovedAppointmentStatus;
                //Add new staff to the crew
                appointment.AppointmentDetail.Crew.CrewDetails.Add(new CrewDetail(){CrewId = appointment.AppointmentDetail.Crew.Id, StaffId = staffId});
            }

            //Save to Database
            await _repositoryWrapper.AppointmentDetail.UpdateAsync(appointment.AppointmentDetail, appointment.AppointmentDetail.Id);
            var appointmentDetail= await _repositoryWrapper.AppointmentDetail.GetAppointmentDetailWithCrew(assignCrewDTO.AppointmentId);
            
            return new AssignCrewResponseDTO()
            {
                AppointmentId = appointmentDetail.AppointmentId,
                StaffIds = appointmentDetail.Crew.CrewDetails.Select(cd=>cd.StaffId).ToList()
            };
        }
    }
}