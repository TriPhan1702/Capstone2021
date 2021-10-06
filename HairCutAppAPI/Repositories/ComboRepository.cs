using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
{
    public class ComboRepository : RepositoryBase<Combo>, IComboRepository
    {
        private readonly HDBContext _hdbContext;

        public ComboRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }
        
        public async Task<IEnumerable<Combo>> GetCombosDetails()
        {
            return await _hdbContext.Combos.Include(c=>c.ComboDetails).ToListAsync();
        }
    }
}