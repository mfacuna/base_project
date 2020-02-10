using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using base_project.Filters;
using System.Reflection;
using System.IO;

namespace base_project.Extensions
{
	internal static class SwaggerExtensions
	{
        internal static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API de Floor Planning",
                    Version = "1.0",
                    Description = "Servicios para el negocio de Floor Planing"
                });
                c.EnableAnnotations();
                c.OperationFilter<AddVersionHeader>();


                // XML Documentation
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        internal static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "API Base");
            });

            return app;
        }

    }
}
