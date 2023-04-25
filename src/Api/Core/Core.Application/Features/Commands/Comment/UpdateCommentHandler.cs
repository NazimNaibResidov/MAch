using AutoMapper;
using Common.CusomterExeptions;
using Common.ViewModel.Models.RequestModel.users;
using Core.Application.Interfaces.Repostoryes;
using MediatR;

namespace Core.Application.Features.Commands.Comment
{
	public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand, bool>
	{
		private readonly ICommentRepsotory repsotory;
		private readonly IMapper mapper;

		public UpdateCommentHandler(ICommentRepsotory repsotory, IMapper mapper)
		{
			this.repsotory = repsotory;
			this.mapper = mapper;
		}
		public async Task<bool> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
		{
			var ifExists = await repsotory.GetSingleAsync(x => x.Id == request.Id);
			if (ifExists is null)
				throw new DataBaseValidatorExeption("comment Not Found");
			var result = mapper.Map<Domain.Comment>(request);
			return await repsotory.UpdateAsync(result) > 0;

		}
	}
}
