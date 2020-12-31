using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Abstractions;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class BaseRepository<TE> : IRepository<TE> where TE : class
    {
        protected readonly DbSet<TE> Entities;
        protected readonly DataContext Context;

        protected BaseRepository(DataContext context)
        {
            Context = context;
            Entities = context.Set<TE>();
        }

        public async Task<TE> AddAsync(TE entity)
        {
            await Entities.AddAsync(entity);
            return entity;
        }

        public async Task<TE> GetAsync(Expression<Func<TE, bool>> func, bool isTracked = true)
        {
            return isTracked
                ? await Entities.AsQueryable().FirstAsync(func)
                : await Entities.AsNoTracking().FirstAsync(func);
        }

        public bool Contains(Expression<Func<TE, bool>> func)
        {
            return Entities.FirstOrDefault(func) != null;
        }

        public async Task<bool> ContainsAsync(Expression<Func<TE, bool>> func)
        {
            return await Entities.FirstOrDefaultAsync(func) != null;
        }

        public async Task RemoveAsync(Expression<Func<TE, bool>> func)
        {
            Entities.Remove(await Entities.FirstAsync(func));
            await Context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

        public TE StarTracking(TE entity)
        {
            Entities.Update(entity);
            return entity;
        }

        public async Task<IEnumerable<TE>> GetAllAsync()
        {
            return await Entities.ToArrayAsync();
        }

        public IQueryable<TE> GetAsQueryable()
        {
            return Entities.AsQueryable();
        }
    }
}