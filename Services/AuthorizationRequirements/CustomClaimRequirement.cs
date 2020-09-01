using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VEMS.Services.AuthorizationRequirements
{
    public class CustomClaimRequirement: IAuthorizationRequirement
    {
        public CustomClaimRequirement(string claimType)
        {
            ClaimType = claimType;
        }

        public string ClaimType { get; }
    }
}
