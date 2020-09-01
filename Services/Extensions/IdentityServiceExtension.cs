using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.Data;
using VEMS.Models.DB.Identity;

namespace VEMS.Services.Extensions
{
    public static class IdentityServiceExtension
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
