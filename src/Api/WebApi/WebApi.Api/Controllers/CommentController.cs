using Common.ViewModel.Models.Quiers.Comment;
using Common.ViewModel.Models.RequestModel.users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Api.Controllers
{
    public class CommentController : BaseController
    {
        private readonly IMediator mediator;
        private readonly ILogger<CommentController> _logger;

        public CommentController(IMediator mediator, ILogger<CommentController> logger)
        {
            this.mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetCommentQuery());
            return Ok(result);
        }
        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> Greate([FromBody] CreateCommentCommand command)
        {
            var result = await mediator.Send(command);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                _logger.LogError("occured error Create ");
                return BadRequest();
            }

        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCommentCommand command)
        {
            var result = await mediator.Send(command);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                _logger.LogError("occured error Update");
                return BadRequest();
            }

        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var command = new DeleteCommentCommand(id);
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
