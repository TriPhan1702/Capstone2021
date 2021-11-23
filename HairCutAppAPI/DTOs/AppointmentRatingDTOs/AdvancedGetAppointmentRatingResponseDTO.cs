namespace HairCutAppAPI.DTOs.AppointmentRatingDTOs
{
    public class AdvancedGetAppointmentRatingResponseDTO
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int Rating { get; set; }
        public string RatingComment { get; set; }
    }
}