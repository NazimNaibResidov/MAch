using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.Sedding
{
    public class SeedData
    {
        public async Task SeedAsync(string CONNETION_STRING_NAME)
        {
            var optionsBuilder = new DbContextOptionsBuilder().UseSqlite(CONNETION_STRING_NAME);

            var _optionBuilder = new DbContextOptions<MachinContext>();

            var context = new MachinContext(_optionBuilder);
            var result = CommanSeed.GetComments();

            await context.Comments.AddRangeAsync(result);


            await context.SaveChangesAsync();
        }
        public static void SeedAsync(IServiceCollection services)
        {
            ;
            var context = services.BuildServiceProvider().GetRequiredService<MachinContext>();
            context.Comments.AddRange(CommanSeed.GetComments());
            var user = CommanSeed.GetUser();
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
