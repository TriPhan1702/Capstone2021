namespace HairCutAppAPI.DTOs.ArticleDTOs
{
    public class AdvancedGetArticleResponseDTO
    {
        public int Id { get; set; }
        public int AuthorUserId { get; set; }
        public string AuthorName { get; set; }
        public string Tittle { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string LastUpdate { get; set; }
        
        public string AvatarUrl { get; set; }
    }
}