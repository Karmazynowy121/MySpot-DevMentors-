

using Microsoft.Extensions.DependencyInjection;
using MySpot.Application.Abstractions;

namespace MySpot.Aplication
{
    public static class Extensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ICommandHandler<>).Assembly;

            services.Scan(s => s.FromAssemblies(applicationAssembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            return services;
        }
    }
}
