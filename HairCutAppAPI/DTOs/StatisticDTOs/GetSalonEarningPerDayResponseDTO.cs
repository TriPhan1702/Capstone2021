using System.Collections.Generic;

namespace HairCutAppAPI.DTOs.StatisticDTOs
{
    public class GetSalonEarningPerDayResponseDTO
    {
        public int SalonId { get; set; }
        public string SalonName { get; set; }
        public List<GetSalonEarningPerDayResponseDayInfoDTO> DayInfos { get; set; }
    }

    public class GetSalonEarningPerDayResponseDayInfoDTO
    {
        public string Date { get; set; }
        public long TotalEarning { get; set; }
    }
}