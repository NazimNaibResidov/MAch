using Common.Core.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [JwtAuthorizeAttribute]
    public class BaseController : ControllerBase
    {

        public int? UserId => Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
}
