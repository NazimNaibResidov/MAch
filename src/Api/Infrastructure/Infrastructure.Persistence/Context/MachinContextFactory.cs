using Common.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence.Context
{
    public class MachinContextFactory : IDesignTimeDbContextFactory<MachinContext>
    {
        public MachinContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MachinContext>();
            optionsBuilder.UseSqlite(Constants.CONNETION_STRING_SQLLITE_NAME);
            return new MachinContext(optionsBuilder.Options);
        }
    }
}
