using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LicenseService.Commands;
using LicenseService.Queries;
using LicenseService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Needed for TenantProvider
builder.Services.AddHttpContextAccessor();

// 🔹 REGISTER TENANT PROVIDER
builder.Services.AddScoped<ITenantProvider, TenantProvider>();

// 🔹 REGISTER CQRS HANDLERS
builder.Services.AddScoped<ApplyLicenseCommandHandler>();
builder.Services.AddScoped<GetLicensesQuery>();

// JWT Configuration
var jwt = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwt["Key"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwt["Issuer"],
        ValidAudience = jwt["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
