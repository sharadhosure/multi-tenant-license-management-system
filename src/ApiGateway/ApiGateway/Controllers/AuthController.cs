using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok("API Gateway is running");
        }
    }
}
