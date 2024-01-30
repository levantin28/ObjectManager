using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OM.Common.Extensions;
using OM.Services.ObjectManager.DAL.Context;
using OM.Services.ObjectManager.DAL.Repositories.GeneralObjects;
using OM.Services.ObjectManager.DAL.Repositories.Relations;

namespace OM.Services.ObjectManager.DAL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // Extension method to add Data Access Layer (DAL) services to the IServiceCollection.
        public static void AddDAL(this IServiceCollection services, IConfiguration configuration)
        {
            // Add the main database context (OMDbContext) to the service collection.
            services.AddOMDbContext<OMDbContext>(configuration);

            // Add repositories to the service collection using a separate method.
            services.AddRepositories();
        }

        // Private method to add repository services to the IServiceCollection.
        private static void AddRepositories(this IServiceCollection services)
        {
            // Add a transient service for GeneralObjectRepository, responsible for handling GeneralObject entities.
            services.AddTransient<IGeneralObjectRepository, GeneralObjectRepository>();

            // Add a transient service for RelationRepository, responsible for handling Relation entities.
            services.AddTransient<IRelationRepository, RelationRepository>();
        }

    }
}
