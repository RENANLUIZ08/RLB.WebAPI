using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using App.RLB.WebAPI.Data;
using EF.Infrastructure.Data.Repositories;
using App.RLB.WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace EF_Infrastructure.ServicesCollection
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddIdentity(IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
