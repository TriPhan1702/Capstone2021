﻿using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ArticleDTOs;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairCutAppAPI.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ArticleService(IRepositoryWrapper repositoryWrapper, IHttpContextAccessor httpContextAccessor)
        {
            _repositoryWrapper = repositoryWrapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> CreateArticle( CreateArticleDTO dto)
        {
            var currentUserId = GetCurrentUserId();

            var newArticle = dto.ToNewArticle(currentUserId);

            var result = await _repositoryWrapper.Article.CreateAsync(newArticle);
            
            return new CustomHttpCodeResponse(200, "ArticleCreated", result.Id);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> GetArticleDetail(int id)
        {
            var article = await _repositoryWrapper.Article.FindSingleByConditionWithIncludeAsync(art => art.Id == id, article1 => article1.Author);
            if (article is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Article with Id {id} not found");
            }
            return new CustomHttpCodeResponse(200,"", article.ToArticleDetailDTO());
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> UpdateArticle(UpdateArticleDTO dto)
        {
            var article = await _repositoryWrapper.Article.FindSingleByConditionAsync(art => art.Id == dto.Id);
            if (article is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Article with Id {dto.Id} not found");
            }
            article = dto.MapAndUpdateArticle(article);
            await _repositoryWrapper.Article.UpdateAsync(article, article.Id);
            return new CustomHttpCodeResponse(200,"Article Updated", true);
        }

        public async Task<ActionResult<CustomHttpCodeResponse>> DeActivateArticle(int id)
        {
            var article = await _repositoryWrapper.Article.FindSingleByConditionAsync(art => art.Id == id);
            if (article is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Article with Id {id} not found");
            }

            if (article.Status.ToLower() == GlobalVariables.InActiveArticleStatus)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Article is already InActive");
            }

            article.Status = GlobalVariables.InActiveArticleStatus;
            var result = await _repositoryWrapper.Article.UpdateAsync(article, article.Id);
            return new CustomHttpCodeResponse(200,"Article Updated", result.Status);
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> ActivateArticle(int id)
        {
            var article = await _repositoryWrapper.Article.FindSingleByConditionAsync(art => art.Id == id);
            if (article is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Article with Id {id} not found");
            }
            
            if (article.Status.ToLower() == GlobalVariables.ActiveArticleStatus)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Article is already Active");
            }

            article.Status = GlobalVariables.InActiveArticleStatus;
            var result = await _repositoryWrapper.Article.UpdateAsync(article, article.Id);
            return new CustomHttpCodeResponse(200,"Article Updated", result.Status);
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> AdvancedGetArticles(AdvancedGetArticleDTO dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.SortBy) && !AdvancedGetArticleDTO.OrderingParams.Contains(dto.SortBy.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"OrderBy must be: " + string.Join(", ", AdvancedGetArticleDTO.OrderingParams));
            }
            
            var result = await _repositoryWrapper.Article.AdvancedGetArticles(dto);
            return new CustomHttpCodeResponse(200, "" , result);
        }
        
        public async Task<ActionResult<CustomHttpCodeResponse>> CustomerAdvancedGetArticles(CustomerAdvancedGetArticleDTO dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.SortBy) && !CustomerAdvancedGetArticleDTO.OrderingParams.Contains(dto.SortBy.ToLower()))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest,"OrderBy must be: " + string.Join(", ", CustomerAdvancedGetArticleDTO.OrderingParams));
            }
            
            var result = await _repositoryWrapper.Article.AdvancedGetArticles(dto.ToAdvancedGetArticleDTO());
            return new CustomHttpCodeResponse(200, "" , result);
        }
        
        private int GetCurrentUserId()
        {
            int currentUserId;
            if (_httpContextAccessor.HttpContext == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"No current user is active");
            }

            try
            {
                //Get Current user Id
                currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            catch (ArgumentNullException e)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Current User Id not Found");
            }

            return currentUserId;
        }
    }
}