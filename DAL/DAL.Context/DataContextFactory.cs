using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAL.Context
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + "/../../Core")
                .AddJsonFile("appsettings.json")
                .AddJsonFile("configs.json")
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder
                .UseNpgsql(config.GetConnectionString("Data"));
            return new DataContext(optionsBuilder.Options, config);
        }
    }
}