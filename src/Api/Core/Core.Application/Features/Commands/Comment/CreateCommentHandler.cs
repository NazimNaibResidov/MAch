using AutoMapper;
using Common.ViewModel.Models.RequestModel.users;
using Core.Application.Interfaces.Repostoryes;
using MediatR;

namespace Core.Application.Features.Commands.Comment
{
	public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, bool>
	{
		private readonly ICommentRepsotory repsotory;
		private readonly IMapper mapper;

		public CreateCommentHandler(ICommentRepsotory repsotory, IMapper mapper)
		{
			this.repsotory = repsotory;
			this.mapper = mapper;
		}

		public async Task<bool> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
		{
			var mapperResult = mapper.Map<Domain.Comment>(request);
			return await repsotory.AddAsync(mapperResult) > 0;

		}
	}
}
