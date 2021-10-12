using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairCutAppAPI.DTOs.AppointmentDTOs;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        [ForeignKey("Salon")]
        public int SalonId { get; set; }
        public Salon Salon { get; set; }

        [ForeignKey("Rating")]
        public int? RatingId { get; set; }
        public AppointmentRating Rating { get; set; }
        
        [ForeignKey("AppointmentDetail")]
        public int AppointmentDetailId { get; set; }
        public AppointmentDetail AppointmentDetail { get; set; }
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        
        [MaxLength(255)]
        public string Note { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
        
        [MaxLength(20)]
        public string PaymentType { get; set; }
        
        [MinLength(3), MaxLength(255)]
        public string PromotionalCode { get; set; }
        
        [Url]
        public string ImageUrl { get; set; }

        public CreateAppointmentResponseDTO ToCreateAppointmentResponseDTO(decimal price, int? stylistId = null, string stylistName = null)
        {
            return new CreateAppointmentResponseDTO()
            {
                Id = Id,
                Price = price,
                Status = Status,
                CreatedDate = CreatedDate.ToString(GlobalVariables.DayFormat),
                PromotionalCode = PromotionalCode,
                ComboId = AppointmentDetail.ComboId,
                CustomerId = CustomerId,
                CustomerName = Customer.FullName,
                StartDate = StartDate.ToString(GlobalVariables.DateTimeFormat),
                EndDate = StartDate.ToString(GlobalVariables.DateTimeFormat),
                SalonId = SalonId,
                SalonName = Salon.Name,
                StylistId = stylistId,
                StylistName = stylistName,
                AppointmentDetailId = AppointmentDetailId
            };
        }

        public ChangeAppointmentStatusResponseDTO ToChangeAppointmentStatusResponseDTO()
        {
            return new ChangeAppointmentStatusResponseDTO()
            {
                AppointmentId = Id,
                Status = Status
            };
        }
    }
}