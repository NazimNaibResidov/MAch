using Core.Application.Interfaces.Repostoryes;
using Core.Domain;
using Infrastructure.Persistence.core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repostorys.Repostoryes
{
	public class UserRepsotory : GenericRepostory<User>, IUserRepsotory
	{
		public UserRepsotory(DbContext context) : base(context)
		{
		}
	}
}
