namespace HairCutAppAPI.DTOs.StaffDTOs
{
    public class GetAvailableStylistsOfASalonInSpanOfDayResponseDTO
    {
        public int StaffId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
    }
}