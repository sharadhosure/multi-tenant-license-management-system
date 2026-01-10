using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/documents")]
    public class DocumentController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok("Document service placeholder");
        }
    }
}
