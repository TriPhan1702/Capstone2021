namespace HairCutAppAPI.DTOs.StatisticDTOs
{
    public class TopChosenStaffResponseDTO
    {
        public int StaffId { get; set; }
        public int StaffUserId { get; set; }
        public string Name { get; set; }
        public string StaffType { get; set; }
        public int TimesChosen { get; set; }
    }
}