using MediatR;

namespace Common.ViewModel.Models.Quiers.Comment
{
    public class GetCommentQuery : IRequest<List<GetCommentQueryViewModel>>
    {
    }
    public class GetCommentQueryViewModel
    {
        public GetCommentQueryViewModel()
        {

        }
        public GetCommentQueryViewModel(int id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
