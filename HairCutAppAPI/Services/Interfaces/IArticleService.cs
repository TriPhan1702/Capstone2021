﻿using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ArticleDTOs;
using HairCutAppAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services.Interfaces
{
    public interface IArticleService
    {
        /// <summary>
        /// DEBUG
        /// </summary>
        Task<ActionResult<CustomHttpCodeResponse>> GetAllArticles();
        Task<ActionResult<CustomHttpCodeResponse>> CreateArticle(CreateArticleDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> GetArticleDetail(int id);
        Task<ActionResult<CustomHttpCodeResponse>> CustomerGetArticleDetail(int id);
        Task<ActionResult<CustomHttpCodeResponse>> UpdateArticle(UpdateArticleDTO dto);
        Task<ActionResult<CustomHttpCodeResponse>> DeActivateArticle(int id);
        Task<ActionResult<CustomHttpCodeResponse>> ActivateArticle(int id);
        Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetArticles(AdvancedGetArticleDTO dto);
        ActionResult<CustomHttpCodeResponse> GetSortByForAdvancedGetArticles();
        Task<ActionResult<CustomHttpCodeResponse>> CustomerAdvancedGetArticles(CustomerAdvancedGetArticleDTO dto);
    }
}