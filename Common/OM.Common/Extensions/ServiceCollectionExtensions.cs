using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using OM.Common.CQRS.Commands.Dispatcher;
using OM.Common.CQRS.Queries.Dispatcher;
using OM.Common.CQRS.Commands.Handler;
using OM.Common.CQRS.Queries.Handler;
using OM.Common.CQRS.Commands.Validator;
using Microsoft.EntityFrameworkCore;
using static OM.Common.Factories.ConnectionStringFactory;
using OM.Common.Constants;

namespace OM.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // Adds services related to the Business Logic Layer (BLL).
        public static void AddBLL(this IServiceCollection services, Assembly assembly, IConfiguration configuration)
        {
            // Adds dispatchers, command handlers, command validators, and query handlers.
            services.AddDispatchers();
            services.AddCommandHandlers(assembly);
            services.AddCommandValidators(assembly);
            services.AddQueryHandlers(assembly);
        }

        // Adds command and query dispatchers as transient services.
        public static void AddDispatchers(this IServiceCollection services)
        {
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            services.AddTransient<IQueryDispatcher, QueryDispatcher>();
        }

        // Adds command handlers based on the provided assembly.
        public static void AddCommandHandlers(this IServiceCollection services, Assembly assembly)
        {
            services.AddImplementationsOfType(typeof(ICommandHandler<>), assembly);
        }

        // Adds query handlers based on the provided assembly.
        public static void AddQueryHandlers(this IServiceCollection services, Assembly assembly)
        {
            services.AddImplementationsOfType(typeof(IQueryHandler<,>), assembly);
        }

        // Adds command validators based on the provided assembly.
        public static void AddCommandValidators(this IServiceCollection services, Assembly assembly)
        {
            services.AddImplementationsOfType(typeof(ICommandValidator<>), assembly);
        }

        // Adds implementations of a specified type as transient services.
        public static void AddImplementationsOfType(this IServiceCollection services, Type type, Assembly assembly = null)
        {
            // Registers implementations of the provided type and their corresponding interfaces.
            type.GetDefinitionAndImplementationsOfType(assembly).ForEach(ht => services.AddTransient(ht.Key, ht.Value));
        }

        // Adds Swagger generation services.
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
        }

        // Adds custom health checks.
        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services)
        {
            var hcBuilder = services.AddHealthChecks();

            // Adds a self-check that always returns a healthy result.
            hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());

            return services;
        }

        // Runs database migrations for a specified DbContext.
        public static void RunMigrations<TContext>(this IServiceProvider provider)
            where TContext : DbContext
        {
            using var scope = provider.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<TContext>();

            // Executes database migrations for the specified DbContext.
            context.Database.Migrate();
        }

        // Adds an Entity Framework DbContext with SQL Server as the data store.
        public static void AddOMDbContext<TContext>(this IServiceCollection services, IConfiguration configuration)
            where TContext : DbContext, new()
        {
            // Configures the DbContext to use SQL Server with connection string from configuration.
            services.AddDbContext<TContext>(options =>
                options.UseSqlServer(configuration.GetValue<string>(EnvironmentVariableConstants.DbConnectionString)));
        }

        // Adds common infrastructure services.
        public static void AddCommonInfrastructure(this IServiceCollection services)
        {
            // This method is currently empty and may be expanded with additional common infrastructure services.
        }
    }
}
