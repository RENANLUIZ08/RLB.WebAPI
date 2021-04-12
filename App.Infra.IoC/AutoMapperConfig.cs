using App.RLB.Application.AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace App.Infra.IoC
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            //services.AddControllers().AddFluentValidation(p =>
            //{
            //    p.RegisterValidatorsFromAssemblyContaining<MappingEntity>();
            //    p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
            //});

            services.AddAutoMapper(x => x.AddProfile(new MappingEntity()));
        }
    }
}
