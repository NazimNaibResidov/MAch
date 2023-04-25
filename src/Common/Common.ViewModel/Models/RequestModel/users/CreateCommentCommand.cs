using MediatR;

namespace Common.ViewModel.Models.RequestModel.users
{
	public class CreateCommentCommand : IRequest<bool>
	{
		public CreateCommentCommand()
		{

		}
		public CreateCommentCommand(string title, string content)
		{
			Title = title;
			Content = content;
		}

		public string Title { get; set; }
		public string Content { get; set; }
	}
}