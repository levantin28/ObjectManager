﻿using OM.Common.Extensions;
using OM.Services.ObjectManager.BLL.Queries.GeneralObjects;
using OM.Services.ObjectManager.DAL.Extensions;
using System.Reflection;

namespace OM.Services.ObjectManager.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method is called by the runtime to configure services in the DI container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC controllers to the service collection.
            services.AddControllers();

            // Add Swagger for API documentation.
            services.AddSwagger();

            // Configure Business Logic Layer (BLL) services, Data Access Layer (DAL) services, and custom health checks.
            services.AddBLL(Assembly.GetAssembly(typeof(GetGeneralObjectQuery)), Configuration);
            services.AddDAL(Configuration);
            services.AddCustomHealthChecks();
        }

        // This method is called by the runtime to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            // Check if the application is in development mode.
            if (env.IsDevelopment())
            {
                // Enable Swagger middleware for API documentation in development mode.
                app.UseSwaggerMiddleware();
            }

            // Run database migrations on application startup.
            services.RunMigrations();

            // Configure routing for the application.
            app.UseRouting();

            // Enable Cross-Origin Resource Sharing (CORS) for all origins, methods, and headers.
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true));

            // Configure endpoints for controllers and custom health checks.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapCustomHealthChecks();
            });
        }
    }
}
