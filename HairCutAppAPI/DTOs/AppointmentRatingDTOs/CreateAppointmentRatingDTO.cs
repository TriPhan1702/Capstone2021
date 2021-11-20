using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.DTOs.AppointmentRatingDTOs
{
    public class CreateAppointmentRatingDTO
    {
        public int AppointmentId { get; set; }
        
        [Required]
        public int Rating { get; set; }
        
        [MaxLength(500)]
        public string RatingComment { get; set; }

        public AppointmentRating ToNewAppointmentRating()
        {
            return new AppointmentRating()
            {
                Rating = Rating,
                RatingComment = RatingComment,
                AppointmentId = AppointmentId
            };
        }
    }
}