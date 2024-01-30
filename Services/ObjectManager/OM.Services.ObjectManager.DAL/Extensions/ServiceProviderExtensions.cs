using OM.Common.Extensions;
using OM.Services.ObjectManager.DAL.Context;

namespace OM.Services.ObjectManager.DAL.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void RunMigrations(this IServiceProvider serviceProvider)
        {
            serviceProvider.RunMigrations<OMDbContext>();
        }
    }
}
