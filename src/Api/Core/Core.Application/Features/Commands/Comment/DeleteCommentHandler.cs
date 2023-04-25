using AutoMapper;
using Common.CusomterExeptions;
using Common.ViewModel.Models.RequestModel.users;
using Core.Application.Interfaces.Repostoryes;
using MediatR;

namespace Core.Application.Features.Commands.Comment
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, bool>
    {
        private readonly ICommentRepsotory repsotory;
        private readonly IMapper mapper;

        public DeleteCommentHandler(ICommentRepsotory repsotory, IMapper mapper)
        {
            this.repsotory = repsotory;
            this.mapper = mapper;
        }
        public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var ifExists = await repsotory.GetSingleAsync(x => x.Id == request.Id);
            if (ifExists is null)
                throw new DataBaseValidatorExeption("comment Not Found");

            return await repsotory.DeleteAsync(ifExists) > 0;

        }
    }
}
