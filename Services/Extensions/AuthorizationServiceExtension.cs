using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VEMS.Services.AuthorizationRequirements;

namespace VEMS.Services.Extensions
{
    public static class AuthorizationServiceExtension
    {
        public static void AddAuthorizationConfiguration(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Policy.AdminRole", policy => policy.RequireCustomClaim(ClaimTypes.Role));

            });


            services.AddScoped<IAuthorizationHandler, CustomClaimRequirementHandler>();


            services.AddCors(options =>
            {
                options.AddPolicy("APIPolicy", builder =>
                {
                    builder
                    .WithOrigins("http://localhost:3001", "http://localhost:2001")
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowedToAllowWildcardSubdomains();
                });

            });
        }
    }
}
