using LicenseService.Infrastructure;
using LicenseService.Models;

namespace LicenseService.Queries
{
    public class GetLicensesQuery
    {
        private readonly ITenantProvider _tenantProvider;

        public GetLicensesQuery(ITenantProvider tenantProvider)
        {
            _tenantProvider = tenantProvider;
        }

        public List<License> Execute()
        {
            // Placeholder – normally fetch from DB
            return new List<License>
            {
                new License
                {
                    LicenseId = Guid.NewGuid(),
                    TenantId = _tenantProvider.GetTenantId(),
                    LicenseNumber = "LIC-001",
                    Status = "Approved",
                    CreatedAt = DateTime.UtcNow
                }
            };
        }
    }
}
