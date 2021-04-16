using App.RLB.Domain.Core.Shared.Validations;
using App.RLB.Domain.Core.Shared.Validations.Commands;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace App.Infra.IoC
{
    public static class FluentValidatorConfig
    {
        public static void AddFluentValidatorConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(p =>
            {
                p.RegisterValidatorsFromAssemblyContaining<NewClienteDTOValidator>();
                //p.RegisterValidatorsFromAssemblyContaining<CommandUpdateCliente>();
                //p.RegisterValidatorsFromAssemblyContaining<CommandDeleteCliente>();

                //p.RegisterValidatorsFromAssemblyContaining<CommandNewPessoaFisica>();
                //p.RegisterValidatorsFromAssemblyContaining<CommandUpdatePessoaFisica>();
                //p.RegisterValidatorsFromAssemblyContaining<CommandDeletePessoaFisica>();

                //p.RegisterValidatorsFromAssemblyContaining<CommandNewPessoaJuridica>();
                //p.RegisterValidatorsFromAssemblyContaining<CommandUpdatePessoaJuridica>();
                //p.RegisterValidatorsFromAssemblyContaining<CommandDeletePessoaJuridica>();

                p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
            });
        }
    }
}
