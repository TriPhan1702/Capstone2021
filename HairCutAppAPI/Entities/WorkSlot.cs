using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairCutAppAPI.DTOs.WorkSlotDTOs;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Entities
{
    public class WorkSlot
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
        
        [ForeignKey("SlotOfDay")]
        public int SlotOfDayId { get; set; }
        public SlotOfDay SlotOfDay { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

        public GetWorkSlotResponseDTO ToGetWorkSlotResponseDTO()
        {
            return new GetWorkSlotResponseDTO()
            {
                Id = Id,
                Status = Status,
                StaffId = StaffId,
                SlotOfDayId = SlotOfDayId,
                Date = Date.ToString(GlobalVariables.DayFormat)
            };
        }

        public UpdateWorkSlotDTO ToUpdateWorkSlotDTO()
        {
            return new UpdateWorkSlotDTO()
            {
                Id = Id,
                Status = Status
            };
        }
    }
}