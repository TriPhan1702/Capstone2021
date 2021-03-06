namespace HairCutAppAPI.DTOs.AppointmentDTOs
{
    public class CreateAppointmentResponseDTO
    {
        public int Id { get; set; }
        
        public int CustomerId { get; set; }
        
        public string CustomerName { get; set; }
        
        public int SalonId { get; set; }
        public string SalonName { get; set; }
        
        public int? StylistId { get; set; }
        
        public string StylistName { get; set; }
        
        public int AppointmentDetailId { get; set; }
        
        public int ComboId { get; set; }
        
        public string Status { get; set; }
        
        public string StartDate { get; set; }
        
        public string EndDate { get; set; }
        
        public string CreatedDate { get; set; }
        
        public string PromotionalCode { get; set; }
        
        public decimal Price { get; set; }
    }
}