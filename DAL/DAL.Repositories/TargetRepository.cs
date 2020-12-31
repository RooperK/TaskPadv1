using DAL.Abstractions;
using DAL.Context;
using DAL.Models;

namespace DAL.Repositories
{
    public class TargetRepository : BaseRepository<Target>, ITargetRepository
    {
        public TargetRepository(DataContext context) : base(context)
        {
        }
    }
}