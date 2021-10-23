using System;
using System.ComponentModel.DataAnnotations;
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
        [RegularExpression(GlobalVariables.DateRegex, ErrorMessage = GlobalVariables.DateRegexMessage)]
        public string ExpirationDate { get; set; }
        [Required]
        public bool IsUniversal { get; set; }
        [Required]
        public int UsesPerCustomer { get; set; }

        public PromotionalCode ToPromotionalCode(DateTime startDate, DateTime endDate)
        {
            return new PromotionalCode()
            {
                Code = Code,
                Percentage = Percentage,
                Status = GlobalVariables.NewPromotionalCodeStatus,
                CreatedDate = DateTime.Now,
                LastUpdate = DateTime.Now,
                StartDate = startDate,
                ExpirationDate = endDate,
                IsUniversal = IsUniversal,
                UsesPerCustomer = UsesPerCustomer
            };
        }
    }
}