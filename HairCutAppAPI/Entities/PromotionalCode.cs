﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.DTOs.PromotionalCodeDTOs;
using HairCutAppAPI.Utilities;

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
        public virtual ICollection<CustomersCodes> CustomersCodes { get; set; }
        
        //Many-Many
        public virtual ICollection<SalonsCodes> SalonsCodes { get; set; }

        public AdvancedGetPromotionalCodesResponseDTO ToAdvancedGetPromotionalCodesResponseDTO()
        {
            return new AdvancedGetPromotionalCodesResponseDTO()
            {
                Id = Id,
                Code = Code,
                Percentage = Percentage,
                CreatedDate = CreatedDate.ToString(GlobalVariables.DateTimeFormat),
                LastUpdate = LastUpdate.ToString(GlobalVariables.DateTimeFormat),
                IsUniversal = IsUniversal,
                StartDate = StartDate.ToString(GlobalVariables.DateTimeFormat),
                ExpirationDate = ExpirationDate.ToString(GlobalVariables.DateTimeFormat)
            };
        }
    }
}