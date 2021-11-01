using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HairCutAppAPI.DTOs.ArticleDTOs;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("Author")]
        public int AuthorUserId { get; set; }
        [Required]
        public virtual AppUser Author { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Tittle { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Status { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }

        public ArticleDetailDTO ToArticleDetailDTO()
        {
            return new ArticleDetailDTO()
            {
                Id = Id,
                Tittle = Tittle,
                Description = Description,
                Status = Status,
                CreatedDate = CreatedDate.ToString(GlobalVariables.DateTimeFormat),
                LastUpdate = LastUpdate.ToString(GlobalVariables.DateTimeFormat),
                AuthorUserId = AuthorUserId,
                AuthorName = Author.FullName,
            };
        }
        
        public ArticleDetailDTO ToArticleDetailDTO( AppUser author)
        {
            return new ArticleDetailDTO()
            {
                Id = Id,
                Tittle = Tittle,
                Description = Description,
                Status = Status,
                CreatedDate = CreatedDate.ToString(GlobalVariables.DateTimeFormat),
                LastUpdate = LastUpdate.ToString(GlobalVariables.DateTimeFormat),
                AuthorUserId = AuthorUserId,
                AuthorName = author.FullName,
            };
        }

        public AdvancedGetArticleResponseDTO ToAdvancedGetArticleResponseDTO()
        {
            return new AdvancedGetArticleResponseDTO()
            {
                Id = Id,
                Tittle = Tittle,
                Status = Status,
                CreatedDate = CreatedDate.ToString(GlobalVariables.DateTimeFormat),
                LastUpdate = LastUpdate.ToString(GlobalVariables.DateTimeFormat),
                AuthorUserId = AuthorUserId,
                AuthorName = Author.FullName,
            };
        }
    }
}