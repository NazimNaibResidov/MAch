using MediatR;

namespace Common.ViewModel.Models.RequestModel.users
{
	public class DeleteCommentCommand : IRequest<bool>
	{
		public DeleteCommentCommand()
		{

		}

		public DeleteCommentCommand(int id)
		{
			Id = id;
		}

		public DeleteCommentCommand(string title, string content)
		{
			Title = title;
			Content = content;
		}
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
	}
}