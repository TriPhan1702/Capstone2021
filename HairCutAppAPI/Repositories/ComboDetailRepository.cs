using System.Collections.Generic;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories.Interfaces
{
    public class ComboDetailRepository : RepositoryBase<ComboDetail>, IComboDetailRepository
    {
        private readonly HDBContext _hdbContext;

        public ComboDetailRepository(HDBContext hdbContext) : base(hdbContext)
        {
            _hdbContext = hdbContext;
        }
    }
}