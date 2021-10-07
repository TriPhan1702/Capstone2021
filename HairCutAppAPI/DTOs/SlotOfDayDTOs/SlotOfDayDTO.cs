using System;

namespace HairCutAppAPI.DTOs.SlotOfDayDTOs
{
    public class SlotOfDayDTO
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}