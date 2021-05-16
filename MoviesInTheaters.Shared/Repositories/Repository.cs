using Microsoft.EntityFrameworkCore;
using MoviesInTheaters.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInTheaters.Shared.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MovieDbContext Context;

        public Repository(MovieDbContext context)
        {
            this.Context = context;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public List<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public ValueTask<TEntity> GetByIdAsync(long id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public bool Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            return true;
        }

        public async Task<bool> Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            return await Task.FromResult(true);
        }
    }
}
