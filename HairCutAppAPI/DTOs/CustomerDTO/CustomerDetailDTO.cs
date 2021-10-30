namespace HairCutAppAPI.DTOs.CustomerDTO
{
    public class CustomerDetailDTO
    {
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarUrl { get; set; }
    }
}