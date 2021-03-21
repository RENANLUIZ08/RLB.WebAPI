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
                        options.UseSqlServer(Configuration.GetConnectionString("Connectionstring")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RLB.WebAPI", Version = "v1" });
            });
            services.AddScoped<ClienteService>(sp => {
                // Build your Context Options
                DbContextOptionsBuilder<ApplicationDbContext> optsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optsBuilder.UseSqlServer(Configuration.GetConnectionString("hml"));
                // Build your context (using the options from the builder)
                ApplicationDbContext ctx = new ApplicationDbContext(optsBuilder.Options);
                // Build your unit of work (and pass in the context)
                RepositoryBaseEF<Cliente> uow = new RepositoryBaseEF<Cliente>(ctx);
                // Build your service (and pass in the unit of work)
                ClienteService svc = new ClienteService(uow);
                // Return your Svc
                return svc;
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
