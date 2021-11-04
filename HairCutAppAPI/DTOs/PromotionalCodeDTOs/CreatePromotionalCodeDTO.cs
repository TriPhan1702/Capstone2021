using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.PromotionalCodeDTOs
{
    public class CreatePromotionalCodeDTO
    {
        [Required]
        [MinLength(3), MaxLength(255)]
        public string Code { get; set; }
        [Required]
        public decimal Percentage { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string ExpirationDate { get; set; }
        [Required]
        public bool IsUniversal { get; set; }
        
        public IEnumerable<int> SalonIds { get; set; }
        
        [Required]
        public int UsesPerCustomer { get; set; }

        public PromotionalCode ToPromotionalCode(DateTime startDate, DateTime endDate)
        {
            var result = new PromotionalCode()
            {
                Code = Code.ToLower(),
                Percentage = Percentage,
                Status = DateTime.Now >= startDate?GlobalVariables.ActivePromotionalCodeStatus:GlobalVariables.InActivePromotionalCodeStatus,
                CreatedDate = DateTime.Now,
                LastUpdate = DateTime.Now,
                StartDate = startDate,
                ExpirationDate = endDate,
                IsUniversal = IsUniversal,
                UsesPerCustomer = UsesPerCustomer,
            };

            if (SalonIds.Any())
            {
                result.SalonsCodes = new List<SalonsCodes>();
                foreach (var salonId in SalonIds)
                {
                    result.SalonsCodes.Add(new SalonsCodes()
                    {
                        SalonId = salonId
                    });
                }
            }

            return result;
        }
    }
}