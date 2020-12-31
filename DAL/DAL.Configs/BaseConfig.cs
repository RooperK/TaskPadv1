using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace DAL.Configs
{
    public class BaseConfig<T> where T : class
    {
        protected readonly IEnumerable<IConfigurationSection> Configuration;
        public BaseConfig(IConfiguration configuration)
        {
            var type = typeof(T).Name;
            Configuration = configuration
                .GetSection("Settings")
                .GetSection("Config")
                .GetSection(type)
                .GetChildren();
        }
    }
}