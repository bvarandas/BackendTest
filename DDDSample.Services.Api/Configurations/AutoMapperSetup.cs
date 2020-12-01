using System;
using AutoMapper;
using DDDSample.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;


namespace DDDSample.Services.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services )
        {
            if (services == null) throw new ArgumentException(nameof(services));

            services.AddAutoMapper();

            AutoMapperConfig.RegisterMappings();
        }
    }
}
