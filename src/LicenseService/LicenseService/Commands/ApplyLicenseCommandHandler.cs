using LicenseService.Infrastructure;
using LicenseService.Models;

namespace LicenseService.Commands
{
    public class ApplyLicenseCommandHandler
    {
        private readonly ITenantProvider _tenantProvider;

        public ApplyLicenseCommandHandler(ITenantProvider tenantProvider)
        {
            _tenantProvider = tenantProvider;
        }

        public License Handle(ApplyLicenseCommand command)
        {
            return new License
            {
                LicenseId = Guid.NewGuid(),
                TenantId = _tenantProvider.GetTenantId(),
                LicenseNumber = command.LicenseNumber,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
