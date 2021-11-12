using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HairCutAppAPI.Data;
using HairCutAppAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HairCutAppAPI.Repositories
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
        
        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await HDBContext.Set<T>().CountAsync(expression);
        }

        public async Task<T> FindSingleByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await HDBContext.Set<T>().FirstOrDefaultAsync(expression);
        }
        
        public async Task<T> FindSingleByConditionWithIncludeAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>> include)
        {
            return await HDBContext.Set<T>().Include(include).FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await HDBContext.Set<T>().Where(expression).ToListAsync();
        }
        
        public async Task<IEnumerable<T>> FindByConditionAsyncWithInclude(Expression<Func<T, bool>> expression, Expression<Func<T, object>> include)
        {
            return await HDBContext.Set<T>().Where(expression).Include(include).ToListAsync();
        }
        
        public async Task<IEnumerable<T>> FindByConditionAsyncWithMultipleIncludes(Expression<Func<T, bool>> expression, Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = HDBContext.Set<T>().Where(expression);
            foreach (var include in includes)
            {
                query = HDBContext.Set<T>().Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await HDBContext.Set<T>().AddAsync(entity);
            await HDBContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> CreateWithoutSaveAsync(T entity)
        {
            await HDBContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public T CreateWithoutSave(T t)
        {
            HDBContext.Set<T>().Add(t);
            return t;
        }

        public async Task<T> UpdateAsync(T entity, object key)
        {
            if (entity == null)
                return null;
            var exist = await HDBContext.Set<T>().FindAsync(key);
            if (exist == null) return null;
            HDBContext.Entry(entity).CurrentValues.SetValues(entity);
            await HDBContext.SaveChangesAsync();
            return exist;
        }
        
        public async Task<T> UpdateAsyncWithoutSave(T entity, object key)
        {
            if (entity == null)
                return null;
            var exist = await HDBContext.Set<T>().FindAsync(key);
            if (exist == null) return null;
            HDBContext.Entry(exist).CurrentValues.SetValues(entity);
            return exist;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            HDBContext.Set<T>().Remove(entity);
            return await HDBContext.SaveChangesAsync();
        }
        
        public void DeleteWithoutSave(T entity)
        {
            HDBContext.Set<T>().Remove(entity);
        }
    }
}