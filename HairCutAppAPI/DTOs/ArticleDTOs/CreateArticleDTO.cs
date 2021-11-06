using System;
using System.ComponentModel.DataAnnotations;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Http;

namespace HairCutAppAPI.DTOs.ArticleDTOs
{
    public class CreateArticleDTO
    {
        [Required]
        [MaxLength(255)]
        public string Tittle { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        public IFormFile AvatarFile { get; set; }

        public Article ToNewArticle(int authorUserId, string avatarUrl)
        {
            return new Article()
            {
                Tittle = Tittle,
                Description = Description,
                CreatedDate = DateTime.Now,
                LastUpdate = DateTime.Now,
                Status = GlobalVariables.NewArticleStatus,
                AuthorUserId = authorUserId,
                AvatarUrl = avatarUrl
            };
        }
    }
}