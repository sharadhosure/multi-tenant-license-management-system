using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NotificationService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/notifications")]
    public class NotificationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Notify()
        {
            return Ok("Notification triggered (placeholder)");
        }
    }
}
