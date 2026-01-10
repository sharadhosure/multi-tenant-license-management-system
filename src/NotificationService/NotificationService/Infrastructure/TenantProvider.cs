
using Microsoft.AspNetCore.Http;

public class TenantProvider : ITenantProvider
{
    private readonly IHttpContextAccessor _context;
    public TenantProvider(IHttpContextAccessor context) { _context = context; }

    public Guid GetTenantId()
    {
        var tenantId = _context.HttpContext?.User?.FindFirst("TenantId")?.Value;
        if (string.IsNullOrEmpty(tenantId))
            throw new Exception("TenantId missing");
        return Guid.Parse(tenantId);
    }
}
