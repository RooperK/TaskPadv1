using System.Collections.Generic;
using API.Models.Mapping;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    public static class ControllerSetup
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration, IList<Profile>
            profiles)
        {
            services
                .AddSingleton(new MapperConfiguration(cfg =>
                    {
                        /*cfg.AddMaps(Assembly.GetAssembly(typeof(TargetMapping)));*/
                        cfg.AddProfile(new TargetModelMapping());
                        cfg.AddProfiles(profiles);
                    })
                    .CreateMapper())
                .AddControllers();
        }
    }
}