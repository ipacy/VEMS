using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using VEMS.Models.DB.Identity;

namespace VEMS.Data.Extensions
{
    public static class IdentityTableConfiguration
    {
        public static void ApplyIdentityTableConfiguration(this ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("Users").HasKey(c => c.Id);
            builder.Entity<ApplicationRole>().ToTable("Roles").HasKey(c => c.Id);
            builder.Entity<ApplicationUserClaim>().ToTable("UserClaims").HasKey(c => c.Id);
            builder.Entity<ApplicationUserRole>().ToTable("UserRoles");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
        }
    }
}
