using LicenseService.Commands;
using LicenseService.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LicenseService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/licenses")]
    public class LicenseController : ControllerBase
    {
        private readonly ApplyLicenseCommandHandler _applyHandler;
        private readonly GetLicensesQuery _getQuery;

        public LicenseController(
            ApplyLicenseCommandHandler applyHandler,
            GetLicensesQuery getQuery)
        {
            _applyHandler = applyHandler;
            _getQuery = getQuery;
        }

        [HttpPost]
        public IActionResult Apply([FromBody] ApplyLicenseCommand command)
        {
            var license = _applyHandler.Handle(command);
            return Ok(license);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var licenses = _getQuery.Execute();
            return Ok(licenses);
        }
    }
}
