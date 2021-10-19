using System.Collections.Generic;
using System.Linq;
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

        public async Task<Combo> GetAComboComboDetails(int id)
        {
            return (await _hdbContext.Combos.Where(c => c.Id == id).Include(c => c.ComboDetails).ToListAsync()).First();
        }
        
        public async Task<IEnumerable<Combo>> GetCombosWithDetails()
        {
            return await _hdbContext.Combos.Include(c=>c.ComboDetails).ToListAsync();
        }

        public async Task<Combo> GetOneComboWithDetails(int comboId)
        {
            return await _hdbContext.Combos.Include(c=>c.ComboDetails).SingleOrDefaultAsync(combo => combo.Id == comboId);
        }

        public async Task<Combo> GetOneComboWithDetailsAndServiceDetails(int comboId)
        {
            return await _hdbContext.Combos.Include(c=>c.ComboDetails).ThenInclude(detail => detail.Service).SingleOrDefaultAsync(combo => combo.Id == comboId);
        }
    }
}