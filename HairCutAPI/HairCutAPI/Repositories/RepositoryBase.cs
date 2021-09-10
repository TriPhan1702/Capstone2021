using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairCutAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace HairCutAPI.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public HDBContext HDBContext { get; set; }
        protected RepositoryBase(HDBContext hdbContext)
        {
            HDBContext = hdbContext;
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await HDBContext.Set<T>().ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await HDBContext.Set<T>().AnyAsync(expression);
        }

        public async Task<T> FindSingleByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await HDBContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await HDBContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await HDBContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var exist = await HDBContext.Set<T>().FindAsync(entity);
            if (exist == null) return null;
            HDBContext.Entry(entity).CurrentValues.SetValues(entity);
            await HDBContext.SaveChangesAsync();
            return exist;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            HDBContext.Set<T>().Remove(entity);
            return await HDBContext.SaveChangesAsync();
        }
    }
}
