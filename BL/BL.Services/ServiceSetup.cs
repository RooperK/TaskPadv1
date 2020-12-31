
using System.Collections.Generic;
using Abstractions;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using BL.Models.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace BL.Services
{
    public static class ServiceSetup
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration,
            out Profile[] profiles)
        {
            services.AddTransient<ITargetService, TargetService>();
            profiles = new Profile[] {new TargetMapping()};
        }
    }
}