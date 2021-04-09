using App.RLB.Application;
using App.RLB.Application.AutoMapper;
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
    public static class InjectorDependencyConfig
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            #region Application
            services.AddScoped(typeof(IAppBase<,>), typeof(ServiceAppBase<,>));
            services.AddScoped<IClienteApp, ClienteApp>();
            #endregion

            #region Domain
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IClienteService, ClienteService>();
            #endregion

            #region Repositorio
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IClienteRepository, ClienteRepository>();
            #endregion
        }
    }
}
