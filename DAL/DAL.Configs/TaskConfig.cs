using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace DAL.Configs
{
    public class TaskConfig : BaseConfig<Target>, IEntityTypeConfiguration<Target>
    {
        public TaskConfig(IConfiguration configuration) : base(configuration)
        {
        }

        public void Configure(EntityTypeBuilder<Target> builder)
        {
            foreach (var section in Configuration) builder.Property(section.Key).HasMaxLength(int.Parse(section.Value));
        }
        
    }
}