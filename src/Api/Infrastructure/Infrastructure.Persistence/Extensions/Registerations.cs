using Common.Core;
using Core.Application.Interfaces.Repostoryes;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Sedding;
using Infrastructure.Repostorys.Repostoryes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repostorys.Extensions
{


    public static class Registerations
    {
        public static IServiceCollection AddPersistenceRegisterations(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString(Constants.CONNETION_STRING_INMEMEORY_NAME);

            services

           .AddDbContext<MachinContext>(options =>
       {
           //options.UseSqlite(connectionString);
           options.UseInMemoryDatabase(connectionString);
       });
            services.AddScoped<DbContext>(sp => sp.GetRequiredService<MachinContext>());
            services.AddRepostory();

            SeedData.SeedAsync(services);
            //seed.SeedAsync(connectionString).GetAwaiter().GetResult();
            return services;
        }

        private static IServiceCollection AddRepostory(this IServiceCollection services)
        {

            services.AddTransient<IUserRepsotory, UserRepsotory>();
            services.AddTransient<ICommentRepsotory, CommentRepsotory>();
            return services;
        }
        private static void Saved(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }


}
