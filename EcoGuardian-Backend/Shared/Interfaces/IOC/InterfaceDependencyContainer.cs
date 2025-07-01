using EcoGuardian_Backend.IAM.Infrastructure.Tokens.JWT.Configuration;
using EcoGuardian_Backend.Shared.Interfaces.ASP.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EcoGuardian_Backend.Shared.Interfaces.IOC;

public static class InterfaceDependencyContainer
{
    public static IServiceCollection AddInterfaceDependencies(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "EcoGuardian API", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
        builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", corsBuilder =>
            {
                corsBuilder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                
            });
        });
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
        return services;
    }
}