using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services.Interfaces;

namespace HairCutAppAPI.Services
{
    public class PromotionalCodeService : IPromotionalCodeService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public PromotionalCodeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
    }
}