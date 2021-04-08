using App.RLB.Application;
using App.RLB.Application.Interfaces;
using App.RLB.Application.Services;
using App.RLB.Domain.Interface;
using App.RLB.Domain.Interface.Repositories;
using App.RLB.Domain.Interface.Services;
using App.RLB.Domain.Services;
using App.RLB.Infra.Data.Repository;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infra.IoC
{
    public class FluentValidatorConfig
    {
        public static void AddFluentValidatorConfiguration(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(p =>
            {
                p.RegisterValidatorsFromAssemblyContaining<CommandNewPessoa>();
                p.RegisterValidatorsFromAssemblyContaining<CommandUpdatePessoa>();
                p.RegisterValidatorsFromAssemblyContaining<CommandDeletePessoa>();

                p.RegisterValidatorsFromAssemblyContaining<CommandDeletePessoa>();
                p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
            });
        }
    }
}
