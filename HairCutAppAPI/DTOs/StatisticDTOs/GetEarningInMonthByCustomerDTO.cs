using System.ComponentModel.DataAnnotations;

namespace HairCutAppAPI.DTOs.StatisticDTOs
{
    public class GetEarningInMonthByCustomerDTO
    {
        [Required]
        public string Date { get; set; }
        [Required]
        public int CustomerUserId { get; set; }
    }
}