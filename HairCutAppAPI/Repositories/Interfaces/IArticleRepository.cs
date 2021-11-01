using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ArticleDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IArticleRepository : IRepositoryBase<Article>
    {
        Task<PagedList<AdvancedGetArticleResponseDTO>> AdvancedGetArticles(AdvancedGetArticleDTO dto);
    }
}