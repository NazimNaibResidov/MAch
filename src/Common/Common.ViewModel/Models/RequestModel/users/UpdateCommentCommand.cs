using MediatR;

namespace Common.ViewModel.Models.RequestModel.users
{
	public class UpdateCommentCommand : IRequest<bool>
	{
		public UpdateCommentCommand()
		{

		}

		public UpdateCommentCommand(int id)
		{
			Id = id;
		}

		public UpdateCommentCommand(string title, string content)
		{
			Title = title;
			Content = content;
		}
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
	}
}