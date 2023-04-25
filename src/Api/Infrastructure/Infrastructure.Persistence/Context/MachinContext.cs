using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
	public class MachinContext : DbContext
	{
		public MachinContext(DbContextOptions<MachinContext> options) : base(options)
		{

		}
		public DbSet<User> Users { get; set; }
		public DbSet<Comment> Comments { get; set; }
	}
}
