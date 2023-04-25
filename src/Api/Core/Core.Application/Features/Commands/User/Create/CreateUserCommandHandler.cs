using AutoMapper;
using Common.CusomterExeptions;
using Common.ViewModel.Models.RequestModel.users;
using Core.Application.Interfaces.Repostoryes;
using MediatR;

namespace Core.Application.Features.Commands.User.Create
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
	{
		private readonly IUserRepsotory _userRepstory;
		private readonly IMapper _mapper;

		public CreateUserCommandHandler(IUserRepsotory userRepstory, IMapper mapper)
		{
			_userRepstory = userRepstory;
			_mapper = mapper;
		}

		public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var existsUser = _userRepstory.GetSingleAsync(x => x.Email == request.Email);
			if (existsUser is not null)
				throw new UserValidatorExeption("user alredy exists");
			var dbUser = _mapper.Map<Domain.User>(request);
			var rows = await _userRepstory.AddAsync(dbUser);

			return await Task.FromResult(rows > 0);
		}
	}
}
