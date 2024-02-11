using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddAuthentication(
        JwtBearerDefaults.AuthenticationScheme
    )
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["IdentityServiceUrl"];
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            NameClaimType = "username",
            ValidIssuer = "identity-svc",
        };
    });

var app = builder.Build();

app.MapReverseProxy();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
