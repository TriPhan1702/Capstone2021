using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.DTOs.AppointmentDTOs
{
    public class GetAppointmentDetailResponseDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int SalonId { get; set; }
        public string SalonName { get; set; }
        public string Status { get; set; }
        
        public int? RatingId { get; set; }
        public int? Rating { get; set; }
        public string RatingComment { get; set; }
        
        public string Note { get; set; }
        
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CreatedDate { get; set; }
        public string LastUpdated { get; set; }
        public string PaymentType { get; set; }
        public string PromotionalCode { get; set; }
        public string ImageUrl { get; set; }

        public int ComboId { get; set; }
        public string ComboName { get; set; }
        public string ComboDescription { get; set; }
        
        public ICollection<GetAppointmentDetailResponseDetailDTO> AppointmentDetails { get; set; }

        public decimal TotalPrice { get; set; }
        public decimal PaidAmount { get; set; }
    }

    public class GetAppointmentDetailResponseDetailDTO
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public decimal ServicePrice { get; set; }
        public int? StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffType { get; set; }
    }
}