using App.RLB.Domain.Core.Shared.Mappings;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace App.Infra.IoC
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(NewClientMappingProfile));
            //services.AddAutoMapper(x => x.AddProfile(new MappingEntity()));
        }
    }
}
