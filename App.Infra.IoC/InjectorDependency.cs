﻿using App.RLB.Application.Interfaces;
using App.RLB.Application.Services;
using App.RLB.Domain.Interface.Repositories;
using App.RLB.Domain.Interface.Services;
using App.RLB.Domain.Services;
using App.RLB.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.RLB.Application;

namespace App.Infra.IoC
{
    public class InjectorDependency
    {
        public static void AddDependency(IServiceCollection services)
        {
            #region Application
            services.AddScoped(typeof(IAppBase<,>), typeof(ServiceAppBase<,>));
            services.AddScoped<IClienteApp, ClienteApp>();
            services.AddAutoMapper(x => x.AddProfile(new MappingEntity()));
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
