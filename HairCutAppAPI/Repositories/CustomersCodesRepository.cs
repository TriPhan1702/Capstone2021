using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;

namespace HairCutAppAPI.Repositories
{
    public class CustomersCodesRepository : RepositoryBase<CustomersCodes>, ICustomersCodesRepository
    {
        public CustomersCodesRepository(HDBContext hdbContext) : base(hdbContext)
        {
        }
    }
}