using System.Threading.Tasks;
using HairCutAppAPI.DTOs.ReviewDTOs;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Utilities;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public interface IReviewRepository : IRepositoryBase<Review>
    {
        Task<PagedList<ReviewDTO>> AdvancedGetReview(AdvancedGetReviewDTO dto);
    }
}