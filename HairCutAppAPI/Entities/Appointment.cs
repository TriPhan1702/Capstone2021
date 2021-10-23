using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        public virtual Customer Customer { get; set; }
        
        [ForeignKey("Salon")]
        public int SalonId { get; set; }
        public virtual Salon Salon { get; set; }
        
        [ForeignKey("ChosenStaff")]
        public int? ChosenStaffId { get; set; }
        public virtual Staff ChosenStaff { get; set; }
        
        [ForeignKey("Combo")]
        public int ComboId { get; set; }
        public virtual Combo Combo { get; set; }

        [ForeignKey("Rating")]
        public int? RatingId { get; set; }
        public virtual AppointmentRating Rating { get; set; }
        public virtual ICollection<AppointmentDetail> AppointmentDetails { get; set; }
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
        
        [Required]
        public decimal PaidAmount { get; set; }
        
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
                ComboId = ComboId,
                CustomerId = CustomerId,
                CustomerName = Customer.FullName,
                StartDate = StartDate.ToString(GlobalVariables.DateTimeFormat),
                EndDate = StartDate.ToString(GlobalVariables.DateTimeFormat),
                SalonId = SalonId,
                SalonName = Salon.Name,
                StylistStaffId = stylistId,
                StylistName = stylistName,
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

        public GetAppointmentDetailResponseDTO ToGetAppointmentDetailResponseDTO(Combo combo)
        {
            var result = new GetAppointmentDetailResponseDTO
            {
                Id = Id,
                Note = Note,
                Rating = RatingId,
                Status = Status,
                CreatedDate = CreatedDate.ToString(GlobalVariables.DateTimeFormat),
                LastUpdated = LastUpdated.ToString(GlobalVariables.DateTimeFormat),
                CustomerId = CustomerId,
                CustomerName = Customer.FullName,
                SalonId = SalonId,
                SalonName = Salon.Name,
                StartDate = StartDate.ToString(GlobalVariables.DateTimeFormat),
                EndDate = EndDate.ToString(GlobalVariables.DateTimeFormat),
                ImageUrl = ImageUrl,
                PaymentType = PaymentType,
                PromotionalCode = PromotionalCode,
                RatingId = RatingId,
                RatingComment = Rating?.RatingComment,
                ComboId = ComboId,
                ComboName = Combo.Name,
                ComboDescription = Combo.Description,
                AppointmentDetails = AppointmentDetails.Select(detail => new GetAppointmentDetailResponseDetailDTO()
                {
                    ServiceId = detail.ServiceId, ServiceDescription = detail.Service.Description,
                }).ToList(),
                PaidAmount = PaidAmount,
                // TotalPrice = Combo.Price,
            };
            return result;
        }
        
        public AdvancedGetAppointmentsResponseDTO ToAdvancedGetAppointmentsResponseDTO()
        {
            var result = new AdvancedGetAppointmentsResponseDTO
            {
                Id = Id,
                Status = Status,
                CreatedDate = CreatedDate.ToString(GlobalVariables.DateTimeFormat),
                LastUpdated = LastUpdated.ToString(GlobalVariables.DateTimeFormat),
                CustomerId = CustomerId,
                CustomerName = Customer.FullName,
                SalonId = SalonId,
                SalonName = Salon.Name,
                StartDate = StartDate.ToString(GlobalVariables.DateTimeFormat),
                EndDate = EndDate.ToString(GlobalVariables.DateTimeFormat),
                ComboId = ComboId,
                ComboName = Combo.Name,
                // TotalPrice = Combo.Price,
            };
            return result;
        }
    }
}