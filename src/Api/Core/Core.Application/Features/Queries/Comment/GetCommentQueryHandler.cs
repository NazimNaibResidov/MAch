using AutoMapper;
using Common.ViewModel.Models.Quiers.Comment;
using Core.Application.Interfaces.Repostoryes;
using MediatR;

namespace Core.Application.Features.Queries.Comment
{
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, List<GetCommentQueryViewModel>>
    {
        private readonly ICommentRepsotory _repsotory;
        private readonly IMapper _mapper;

        public GetCommentQueryHandler(ICommentRepsotory repsotory, IMapper mapper)
        {
            _repsotory = repsotory;
            _mapper = mapper;
        }

        public async Task<List<GetCommentQueryViewModel>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var _result = await _repsotory.GetAllAsync();
            var data = _mapper.Map<List<GetCommentQueryViewModel>>(_result.OrderByDescending(x => x.Id));
            return await Task.FromResult(data);
        }
    }
}
