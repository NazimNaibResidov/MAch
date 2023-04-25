using Core.Application.Interfaces.Repostoryes;
using Core.Domain;
using Infrastructure.Persistence.core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repostorys.Repostoryes
{
	public class CommentRepsotory : GenericRepostory<Comment>, ICommentRepsotory
	{
		public CommentRepsotory(DbContext context) : base(context)
		{
		}
	}
}
