using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Abstractions
{
    public interface IRepository<TE> where TE : class
    {
        public Task<TE> AddAsync(TE entity);
        public Task<TE> GetAsync(Expression<Func<TE, bool>> func, bool isTracked = true);
        public bool Contains(Expression<Func<TE, bool>> func);
        public Task<bool> ContainsAsync(Expression<Func<TE, bool>> func);
        public Task RemoveAsync(Expression<Func<TE, bool>> func);
        public Task SaveChangesAsync();
        public TE StarTracking(TE entity);
        public Task<IEnumerable<TE>> GetAllAsync();
        public IQueryable<TE> GetAsQueryable();
    }
}