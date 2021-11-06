using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Http;

namespace HairCutAppAPI.DTOs.ArticleDTOs
{
    public class UpdateArticleDTO
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Tittle { get; set; }
        
        [MaxLength(20)]
        public string Status { get; set; }
        
        public string Description { get; set; }
        
        public IFormFile AvatarFile { get; set; }

        public Article MapAndUpdateArticle(Article article, string avatarUrl = null)
        {
            var hasChanged = false;

            if (!string.IsNullOrWhiteSpace(Tittle) && Tittle != article.Tittle)
            {
                article.Tittle = Tittle;
                hasChanged = true;
            }
            
            if (!string.IsNullOrWhiteSpace(Status) && Status.ToLower()!= article.Status.ToLower())
            {
                if (!GlobalVariables.ArticleStatuses.Contains(Status.ToLower()))
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Article Status must be: " + string.Join(", ", GlobalVariables.ArticleStatuses));
                }
                article.Status = Status.ToLower();
                hasChanged = true;
            }
            
            if (!string.IsNullOrWhiteSpace(Description))
            {
                article.Description = Description;
                hasChanged = true;
            }

            if (avatarUrl!=null)
            {
                article.AvatarUrl = avatarUrl;
                hasChanged = true;
            }

            if (hasChanged)
            {
                article.LastUpdate = DateTime.Now;
            }
            else
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Nothing can be changed from the information provided");
            }

            return article;
        }
    }
}