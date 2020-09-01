using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VEMS.Services.AuthorizationRequirements
{
    public class CustomClaimRequirementHandler: AuthorizationHandler<CustomClaimRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            CustomClaimRequirement requirement)
        {
            var hasClaim = context.User.Claims.Any(c => c.Type == requirement.ClaimType);

            if (hasClaim)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;

        }
    }
}
