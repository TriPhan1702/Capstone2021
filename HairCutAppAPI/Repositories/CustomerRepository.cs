using System.Linq;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly HDBContext _hdbContext;

        public CustomerRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }

        public async Task<Customer> GetCustomerDetail(int userId)
        {
            return await _hdbContext.Customers.Include(customer => customer.User).FirstOrDefaultAsync(customer => customer.UserId == userId);
        }
    }
}