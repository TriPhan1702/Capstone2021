using System;
using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.WorkSlotDTOs
{
    public class GetWorkSlotDTO
    {
        public int StaffId { get; set; }
        
        public int SlotOfDayId { get; set; }
        
        [Required]
        [RegularExpression(GlobalVariables.DateRegex, ErrorMessage = GlobalVariables.DateRegexMessage)]
        public string Date { get; set; }
    }
}