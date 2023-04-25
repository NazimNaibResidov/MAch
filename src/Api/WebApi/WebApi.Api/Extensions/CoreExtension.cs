using Core.Application.Extensions;
using Infrastructure.Repostorys.Extensions;

namespace WebApi.Api.Extensions
{
    public static class CoreExtension
    {
        public static void LoadAll(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAuthorization();
            services.AddApplicationRegisteration();
            services.AddPersistenceRegisterations(configuration);
            services.RegistertionAuth(configuration);
        }
    }
}
