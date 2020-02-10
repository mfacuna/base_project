using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using base_project.Contracts;
using base_project.Extensions;
using base_project.Models;
using base_project.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace base_project
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
			var connectionString = Configuration.GetValue<string>("ConnectionStrings:DbBaseProject");

			services.AddScoped<IUsersService, UsersService>(serviceProvider => { return new UsersService(); });

			services.AddControllers();
			services.AddDbContext<db_base_projectContext>(options => options.UseSqlServer(connectionString));
			// Register the Swagger  generator, defining 1 or more Swagger documents 
			services.AddSwaggerDocumentation();

			services.AddApiVersioning(o =>
			{
				o.ReportApiVersions = true;
				o.AssumeDefaultVersionWhenUnspecified = true;
				o.DefaultApiVersion = new ApiVersion(1, 0);
				o.ApiVersionReader = new HeaderApiVersionReader("api-version");
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwaggerDocumentation();

			// Enable middleware to Serve swagger-ui (HTML, JS, CSS, etc..),
			// spacifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "API Base v1");
			});

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
