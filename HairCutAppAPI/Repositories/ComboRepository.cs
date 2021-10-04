using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using HairCutAppAPI.Repositories.Interfaces;

namespace HairCutAppAPI.Repositories
{
    public class ComboRepository : RepositoryBase<Combo>, IComboRepository
    {
        public ComboRepository(HDBContext hdbContext) : base(hdbContext)
        {
        }
    }
}