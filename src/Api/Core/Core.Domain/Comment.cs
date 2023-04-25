using Core.Domain.Bases;

namespace Core.Domain
{
	public class Comment : BaseEntity<int>
	{
		public string Title { get; set; }
		public string Content { get; set; }

	}
}
