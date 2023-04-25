﻿using MediatR;

namespace Common.ViewModel.RequestModel.users
{
	public class UpdateUserCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public string FristName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
	}
}