using Common.ViewModel;
using Common.ViewModel.Models.RequestModel.users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;


        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }



        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {

            var res = await mediator.Send(command);
            return Ok(res);
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(res);
        }


    }
}
