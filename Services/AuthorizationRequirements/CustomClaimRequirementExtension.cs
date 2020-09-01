using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VEMS.Services.AuthorizationRequirements
{
    public static class CustomClaimRequirementExtension
    {
        public static void RequireCustomClaim(this AuthorizationPolicyBuilder builder, string claimType)
        {
            builder.AddRequirements(new CustomClaimRequirement(claimType));
        }
    }
}
