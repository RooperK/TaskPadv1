using System.Reflection;
using DAL.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DAL.Models;

namespace DAL.Context
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration): base(options)
        {
            _configuration = configuration;
        }
        
        public DbSet<Target> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configs = Assembly.GetAssembly(typeof(BaseConfig<>));
            if (configs == null) return;
            modelBuilder
                .ApplyConfigurationsFromAssembly(configs);
            base.OnModelCreating(modelBuilder);
        }
    }
}