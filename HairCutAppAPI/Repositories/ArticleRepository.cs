using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.DTOs.ArticleDTOs;
using HairCutAppAPI.DTOs.ComboDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Utilities;
using HairCutAppAPI.Utilities.Errors;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        private readonly HDBContext _hdbContext;

        public ArticleRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }

        public async Task<PagedList<AdvancedGetArticleResponseDTO>> AdvancedGetArticles(AdvancedGetArticleDTO dto)
        {
            var query = _hdbContext.Articles.Include(article => article.Author).AsQueryable();
            //If there's status filtering
            if (dto.FilterStatuses != null && dto.FilterStatuses.Any())
            {
                query = query.Where(article =>
                    dto.FilterStatuses.Select(status => status.ToLower()).Contains(article.Status.ToLower()));
            }
            
            //If there Id filtering
            if (dto.FilterIds != null && dto.FilterIds.Any())
            {
                query = query.Where(article =>
                    dto.FilterIds.Contains(article.Id));
            }
            
            //If there AuthorId filtering
            if (dto.AuthorUserIds != null && dto.AuthorUserIds.Any())
            {
                query = query.Where(article =>
                    dto.AuthorUserIds.Contains(article.AuthorUserId));
            }

            //If There's Tittle Filtering
            if (!string.IsNullOrWhiteSpace(dto.FilterTittle))
            {
                query = query.Where(article => article.Tittle.ToLower().Contains(dto.FilterTittle.ToLower()));
            }

            try
            {
                //If there's CreatedDate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MinCreatedDate))
                {
                    var date = DateTime.ParseExact(dto.MinCreatedDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(article => article.CreatedDate >= date);
                }

                //If there's CreatedDate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MaxCreatedDate))
                {
                    var date = DateTime.ParseExact(dto.MaxCreatedDate, GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(article => article.CreatedDate <= date);
                }

                //If there's LastUpdate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MinLastUpdate))
                {
                        var date = DateTime.ParseExact(dto.MinLastUpdate,
                            GlobalVariables.DateTimeFormat,
                            CultureInfo.InvariantCulture);
                        query = query.Where(article => article.LastUpdate >= date);
                }
                
                //If there's LastUpdate Filtering
                if (!string.IsNullOrWhiteSpace(dto.MaxLastUpdate))
                {
                    var date = DateTime.ParseExact(dto.MaxLastUpdate,
                        GlobalVariables.DateTimeFormat,
                        CultureInfo.InvariantCulture);
                    query = query.Where(article => article.LastUpdate <= date);
                }
            }
            catch (FormatException)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, GlobalVariables.DateTimeFormat);
            }


            //If there's sorting
            if (!string.IsNullOrWhiteSpace(dto.SortBy))
            {
                query = dto.SortBy switch
                {
                    "id_asc" => query.OrderBy(article => article.Id),
                    "id_desc" => query.OrderByDescending(article => article.Id),
                    "authoruserid_asc" => query.OrderBy(article => article.Author.Id),
                    "authoruserid_desc" => query.OrderByDescending(article => article.Author.Id),
                    "authorname_asc" => query.OrderBy(article => article.Author.FullName),
                    "authorname_desc" => query.OrderByDescending(article => article.Author.FullName),
                    "tittle_asc" => query.OrderBy(article => article.Tittle),
                    "tittle_desc" => query.OrderByDescending(article => article.Tittle),
                    "status_asc" => query.OrderBy(article => article.Status),
                    "status_desc" => query.OrderByDescending(article => article.Status),
                    "createddate_asc" => query.OrderBy(article => article.CreatedDate),
                    "createddate_desc" => query.OrderByDescending(article => article.CreatedDate),
                    "lastupdate_asc" => query.OrderBy(article => article.LastUpdate),
                    "lastupdate_desc" => query.OrderByDescending(article => article.LastUpdate),
                    _ => query
                };
            }

            return await PagedList<AdvancedGetArticleResponseDTO>.CreateAsync(
                query.Select(article => article.ToAdvancedGetArticleResponseDTO()), dto.PageNumber,
                dto.PageSize);
        }
    }
}