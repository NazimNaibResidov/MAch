using AutoMapper;
using Common.Core;
using Common.Core.Encryptions;
using Common.CusomterExeptions;
using Common.ViewModel;
using Common.ViewModel.Models.Quiers.users;
using Core.Application.Cores;
using Core.Application.Interfaces.Repostoryes;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Core.Application.Features.Commands.User.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModul>
    {
        private readonly IUserRepsotory _userRepstory;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public LoginUserCommandHandler(IUserRepsotory userRepstory, IMapper mapper, IConfiguration configuration)
        {
            _userRepstory = userRepstory;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public async Task<LoginUserViewModul> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {

            var Dbuser = await _userRepstory.GetSingleAsync(x => x.Email == request.Email);
            if (Dbuser == null)
                throw new UserValidatorExeption("user not found");
            var password = PasswordEncryption.Encryption(request.Password);
            if (Dbuser.Password != password)
                throw new DataBaseValidatorExeption(Constants.PasswordIsWorng);

            var result = mapper.Map<LoginUserViewModul>(Dbuser);
            var cliams = new Claim[]
           {
                new Claim(ClaimTypes.NameIdentifier,Dbuser.Id.ToString()),
                new Claim(ClaimTypes.Email,Dbuser.Email),


           };
            result.Token = GenetateToke.GenerateTokes(configuration, cliams);
            result.IsSuccess = true;
            return result;
        }
    }
}
