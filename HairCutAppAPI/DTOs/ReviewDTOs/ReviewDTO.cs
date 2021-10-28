namespace HairCutAppAPI.DTOs.ReviewDTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int SalonId { get; set; }
        public string SalonName { get; set; }
        public bool Rating { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
    }
}