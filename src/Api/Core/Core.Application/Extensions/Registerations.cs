using AutoMapper;
using Core.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Application.Extensions
{
    public static class Registerations
    {
        public static IServiceCollection AddApplicationRegisteration(this IServiceCollection services)
        {
            // var _Assembly = Assembly.GetExecutingAssembly();
            AddMedatorRegisteration(services);
            MapperConfigurationRegisteration(services, Assembly.GetExecutingAssembly());

            return services;
        }
        private static IServiceCollection AddMedatorRegisteration(IServiceCollection services)
        {
            var result = Assembly.GetExecutingAssembly();
            return services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(result));

        }
        private static IServiceCollection MapperConfigurationRegisteration(IServiceCollection services, Assembly _Assembly)
        {
            services.AddAutoMapper(_Assembly);

            var ms = new MapperConfigurationExpression();
            ms.AddProfile(new MappingProfile());
            var mp = new MapperConfiguration(ms);

            mp.CreateMapper();
            return services;
        }

    }
}
