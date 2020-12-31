using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Context
{
    public static class ContextSetup
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<DataContext>(optionsAction =>
                    optionsAction
                        .UseNpgsql(configuration.GetConnectionString("Data"), o =>
                        {
                            o.MigrationsAssembly("DataContextFactory");
                            o.EnableRetryOnFailure(5, TimeSpan.FromMilliseconds(10),
                                null!);
                        }));
        }
    }
}