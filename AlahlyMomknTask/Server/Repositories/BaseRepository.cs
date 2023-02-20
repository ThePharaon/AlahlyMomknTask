using AlahlyMomknTask.Server.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Principal;

namespace AlahlyMomknTask.Server.Repositories
{
    public interface IBaseRepository<T>
    {

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> whereCondition);
        Task<bool> InsertAsync(T entity);
        bool Update(T oldEntity, T entity);
        bool Delete(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> whereCondition = null);

        Task SaveChangesAsync();

    }
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly MainDBContext Context;
        private IQueryable<T> DbSet;
        public BaseRepository(MainDBContext context)
        {
            Context = context;
            DbSet = Context.Set<T>().AsQueryable();
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> whereCondition = null)
        {
            var query = DbSet;
            if(whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            return await query.ToListAsync();
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> whereCondition)
        {        
            return await DbSet.Where(whereCondition).FirstOrDefaultAsync();
        }
        public virtual async Task<bool> InsertAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            return true;
        }
        public bool Update(T oldEntity,T entity)
        {
            Context.Entry(oldEntity).CurrentValues.SetValues(entity);
            return true;
        }
        public bool Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            return true;
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
