using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.DTOs.WorkSlotDTOs
{
    public class FindWorkSlotsOfTimeSpanDTO
    {
        public int StaffId { get; set; }
        [Required]
        [RegularExpression(GlobalVariables.DateRegex, ErrorMessage = GlobalVariables.DateRegexMessage)]
        public string StartDate { get; set; }
        [Required]
        [RegularExpression(GlobalVariables.DateRegex, ErrorMessage = GlobalVariables.DateRegexMessage)]
        public string EndDate { get; set; }
    }
}