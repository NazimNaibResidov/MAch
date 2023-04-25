using MediatR;

namespace Common.ViewModel.Models.RequestModel.users
{
    public class CreateUserCommand : IRequest<bool>
    {

        public string Email { get; set; }
        public string Password { get; set; }
    }
}