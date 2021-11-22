using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.StatisticDTOs
{
    public class GetEarningInMonthBySalonDTO
    {
        [Required]
        public string Date { get; set; }
        [Required]
        public int SalonId { get; set; }
    }
}