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
        public Customer Customer { get; set; }
        
        [ForeignKey("Salon")]
        public int SalonId { get; set; }
        public Salon Salon { get; set; }
        
        [ForeignKey("Combo")]
        public int ComboId { get; set; }
        public Combo Combo { get; set; }
        public string ComboDescription { get; set; }

        [ForeignKey("Rating")]
        public int? RatingId { get; set; }
        public AppointmentRating Rating { get; set; }
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
                StylistId = stylistId,
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
            var result = new GetAppointmentDetailResponseDTO();
            result.Id = Id;
            result.Note = Note;
            result.Rating = RatingId;
            result.Status = Status;
            result.CreatedDate = CreatedDate.ToString(GlobalVariables.DateTimeFormat);
            result.LastUpdated = LastUpdated.ToString(GlobalVariables.DateTimeFormat);
            result.CustomerId = CustomerId;
            result.CustomerName = Customer.FullName;
            result.SalonId = SalonId;
            result.SalonName = Salon.Name;
            result.StartDate = StartDate.ToString(GlobalVariables.DateTimeFormat);
            result.EndDate = EndDate.ToString(GlobalVariables.DateTimeFormat);
            result.ImageUrl = ImageUrl;
            result.PaymentType = PaymentType;
            result.PromotionalCode = PromotionalCode;
            result.RatingId = RatingId;
            result.RatingComment = Rating?.RatingComment;
            result.ComboId = ComboId;
            result.ComboName = Combo.Name;
            result.ComboDescription = Combo.Description;
            result.AppointmentDetails = AppointmentDetails.Select(detail => new GetAppointmentDetailResponseDetailDTO()
            {
                ServiceId = detail.ServiceId,
                ServiceDescription = detail.Service.Description,
                
            }).ToList();
            result.PaidAmount = PaidAmount;
            result.TotalPrice = Combo.Price;
            return result;
        }
    }
}