using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.PromotionalCodeDTOs
{
    public class UpdatePromotionalCodeDTO
    {
        [Required]
        public int Id { get; set; }
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
    }
}