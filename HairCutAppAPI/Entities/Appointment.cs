using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairCutAppAPI.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        [ForeignKey("Combo")]
        public int ComboId { get; set; }
        public Combo Combo { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        
        [Required]
        public decimal TotalPrice { get; set; }
        
        [Required]
        public decimal PaidAmount { get; set; }
        
        public decimal Rating { get; set; }
        
        [MaxLength(255)]
        public string RatingComment { get; set; }
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
        
        public string PaymentDescription { get; set; }
        
        [Url]
        public string ImageUrl { get; set; }
        
        public ICollection<Notification> Notifications { get; set; }
        
        //Many-Many
        public ICollection<AppointmentsServices> AppointmentsServices { get; set; }
    }
}