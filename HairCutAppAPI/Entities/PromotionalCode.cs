using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.Entities
{
    public class PromotionalCode
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3), MaxLength(255)]
        public string Code { get; set; }
        [Required]
        public decimal Percentage { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        public bool IsUniversal { get; set; }
        [Required]
        public int UsesPerCustomer { get; set; }
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        
        //Many-Many
        public ICollection<CustomersCodes> CustomersCodes { get; set; }
        
        //Many-Many
        public ICollection<SalonsCodes> SalonsCodes { get; set; }
    }
}