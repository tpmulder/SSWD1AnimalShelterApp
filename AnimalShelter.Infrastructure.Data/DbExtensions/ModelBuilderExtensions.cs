using AnimalShelter.Core.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AnimalShelter.Infrastructure.Common.Extensions;
using Microsoft.AspNetCore.Identity;
using AnimalShelter.Core.Models;

namespace AnimalShelter.Infrastructure.Data.DbExtensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyIdentityTableNames(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser<Guid>>().ToTable("ASUsers");
            modelBuilder.Entity<IdentityRole<Guid>>().ToTable("ASRoles");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("ASUserRoles");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("ASUserClaims");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("ASUserLogins");

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("ASRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("ASUserTokens");
        }
    }
}
