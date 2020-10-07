using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.AuthServer.Configuration
{
    public static class IdentityConfiguration
    {
        public static void ConfigureOptions(IdentityOptions options, IConfiguration configuration)
        {
            // Password settings
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Password.RequiredUniqueChars = 4;

            // Lockout settings
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            options.User.RequireUniqueEmail = true;

            // Require Confirmed Email User settings
            if (Convert.ToBoolean(configuration["AnimalShelter:RequireConfirmedEmail"] ?? "true"))
                options.SignIn.RequireConfirmedEmail = true;
        }
    }
}
