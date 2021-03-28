using App.Data.Repositories;
using App.RLB.WebAPI.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using App.RLB.WebAPI.Data;
using App.RLB.WebAPI.Models;
using App.RLB.WebAPI.Services.Interface;
using App.RLB.WebAPI.Services;
using App.RLB.WebAPI.Service;

namespace RLB.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("hml")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RLB.WebAPI", Version = "v1" });
                c.EnableAnnotations();
                
            });
            services.AddScoped(sp =>
            {
                var adc = new ApplicationDbContext(
                    new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(Configuration.GetConnectionString("hml")).Options);
                return new ClienteService(new RepositoryBaseEF<Cliente>(adc));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RLB.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
