using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abstractions
{
    public interface IBaseService<TE, in TI> where TE : class
    {
        public Task<bool> CreateAsync(TE targetDto);
        public Task<bool> UpdateAsync(TE targetDto);
        public Task<IEnumerable<TE>> GetAllAsync();
        public Task<TE> GetAsync(TI id);
        public Task DeleteAsync(TI uuid);
    }
}