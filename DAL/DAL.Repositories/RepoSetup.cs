using DAL.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Repositories
{
    public static class RepoSetup
    {
        public static void Configure(IServiceCollection services)
        {
            services
                .AddTransient<ITargetRepository, TargetRepository>();
        }
    }
}