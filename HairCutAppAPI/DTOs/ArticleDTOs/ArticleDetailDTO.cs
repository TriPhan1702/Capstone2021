using System;
using HairCutAppAPI.Entities;

namespace HairCutAppAPI.DTOs.ArticleDTOs
{
    public class ArticleDetailDTO
    {
        public int Id { get; set; }
        public int AuthorUserId { get; set; }
        public string AuthorName { get; set; }
        public string Tittle { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public string LastUpdate { get; set; }
        
        public string AvatarUrl { get; set; }
    }
}