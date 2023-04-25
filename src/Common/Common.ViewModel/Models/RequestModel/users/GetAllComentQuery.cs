using MediatR;

namespace Common.ViewModel.Models.RequestModel.users
{
	public class GetAllComentQuery:IRequest
	{
		public string Title { get; set; }
		public string Content { get; set; }
	}
}