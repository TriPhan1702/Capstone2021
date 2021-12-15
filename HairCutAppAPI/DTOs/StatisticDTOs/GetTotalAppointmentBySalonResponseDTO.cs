using System.Collections.Generic;

namespace HairCutAppAPI.DTOs.StatisticDTOs
{
    public class GetTotalAppointmentBySalonResponseDTO
    {
        public int SalonId { get; set; }
        public string SalonName { get; set; }
        public List<GetTotalAppointmentBySalonResponseDayInfoDTO> DayInfos { get; set; }
    }
    public class GetTotalAppointmentBySalonResponseDayInfoDTO
    {
        public string Date { get; set; }
        public int TotalAppointment { get; set; }
    }
}