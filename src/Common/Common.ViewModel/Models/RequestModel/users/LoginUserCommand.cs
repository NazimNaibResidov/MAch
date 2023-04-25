using Common.ViewModel.Models.Quiers.users;
using MediatR;

namespace Common.ViewModel
{
    public class LoginUserCommand : IRequest<LoginUserViewModul>
    {
        public LoginUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}