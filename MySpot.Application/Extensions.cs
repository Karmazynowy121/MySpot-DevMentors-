

using Microsoft.Extensions.DependencyInjection;
using MySpot.Application.Services;

namespace MySpot.Aplication
{
    public static class Extensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddScoped<IReservationsService, ReservationsService>();

            return services;
        }
    }
}
