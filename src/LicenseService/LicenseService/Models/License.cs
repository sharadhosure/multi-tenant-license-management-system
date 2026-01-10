namespace LicenseService.Models
{
    public class License
    {
        public Guid LicenseId { get; set; }
        public Guid TenantId { get; set; }
        public string LicenseNumber { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
