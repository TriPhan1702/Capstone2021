using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace HairCutAppAPI.DTOs.AppointmentDTOs
{
    public class FinishAppointmentDTO
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }
    }
}