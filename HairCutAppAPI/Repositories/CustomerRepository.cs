using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HairCutAppAPI.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly HDBContext _hdbContext;

        public CustomerRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }
    }
}