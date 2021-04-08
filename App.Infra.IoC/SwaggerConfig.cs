using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace App.Infra.IoC
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerDoc(IServiceCollection services)
        {
            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "RLB.WebAPI",
                    Version = "v1",
                    Description = "RLB WebApi",
                    Contact = new OpenApiContact 
                    { 
                        Name = "Renan Luiz Blasechi",
                        Email = "renanluiz2241@gmail.com"
                    }
                });
                
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Insira seu Token",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

                c.EnableAnnotations();
                c.AddFluentValidationRules();

            });
        }

        public static void UseSwaggerConfiguration(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RLB.WebAPI v1");
                c.DocExpansion(DocExpansion.None);
            });
        }
    }
}
