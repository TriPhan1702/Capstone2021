using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.WorkSlotDTOs
{
    public class FindOwnWorkSlotsOfDayDTO
    {
        [Required]
        [RegularExpression(GlobalVariables.DateRegex, ErrorMessage = GlobalVariables.DateRegexMessage)]
        public string Date { get; set; }
    }
}