using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using App.RLB.WebAPI.Data;
using App.RLB.WebAPI.Models;

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
            services.AddSwaggerDocumentation();

            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("hml"));
            });

            services.AddControllers();
            //service provider
            services.AddScoped(sp =>
            {
                var adc = new DbContext(
                    new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(Configuration.GetConnectionString("hml")).Options);
                return new ClienteService(new RepositoryBaseEF<Cliente>(adc));
            });
           
            
            ////autentication
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = "JwtBearer";//portador
            //    options.DefaultChallengeScheme = "JwtBearer";

            //}).AddJwtBearer("JwtBearer", options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("rlb-webapi-authentication-validation")),
            //        ClockSkew = TimeSpan.FromMinutes(5),
            //        ValidIssuer = "App.RLB.WebAPI",
            //        ValidAudience = "Swagger"
            //    };
            //});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDocumentation();
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
