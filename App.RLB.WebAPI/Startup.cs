using App.Infra.IoC;
using App.RLB.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using App.RLB.Domain.Validations.Commands;
using App.RLB.Domain.Validations;

namespace RLB.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Contexto>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("hml")));

            InjectorDependencyConfig.AddDependencyInjectionConfig(services);
            SwaggerConfig.AddSwaggerDoc(services);

            services.AddControllers().AddFluentValidation(p => p.RegisterValidatorsFromAssemblyContaining<PersonValidation>());            
        
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SwaggerConfig.UseSwaggerConfiguration(app);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
