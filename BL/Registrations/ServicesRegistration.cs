using BL.Services;
using DAL.DbContexts;
using Microsoft.Extensions.DependencyInjection;

namespace BL.Registrations
{
    public static class ServicesRegistration
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddHostedService<GetDataFromUrlService>();
            service.AddTransient<DataService>();
        }
    }
}
