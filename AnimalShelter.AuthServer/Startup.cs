using AnimalShelter.AuthServer.Configuration;
using AnimalShelter.AuthServer.Configuration.Options;
using AnimalShelter.AuthServer.Models;
using AnimalShelter.Core.Constants;
using AnimalShelter.Core.Models.Identity;
using AnimalShelter.Core.Services.Data;
using AnimalShelter.Infrastructure.Data.Contexts;
using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AnimalShelter.AuthServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var identityServerSettings = Configuration.GetSection(IdentityServerSettings.Section)
                .Get<IdentityServerSettings>();

            var identityServerConfig = new IdentityServerConfiguration(identityServerSettings);

            services.Configure<AccountOptions>(e =>
            {
                e.AutomaticRedirectAfterSignOut = true;
            });

            services.Configure<ConsentOptions>(e =>
            {
                e.EnableOfflineAccess = false;
            });

            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString(ConfigurationConstants.AuthDbConnectionString)));

            services.AddIdentity<ASUser, ASRole>(e => IdentityConfiguration.ConfigureOptions(e, Configuration))
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(e =>
            {
                var controllerName = "Account";

                e.Cookie.Name = "IdentityServer.Cookie";
                e.LoginPath = $"/{controllerName}/Login";
                e.LogoutPath = "/Home/Index";
                e.AccessDeniedPath = $"/{controllerName}/AccesDenied";
            });

            var isBuilder = services.AddIdentityServer()
                .AddInMemoryClients(identityServerConfig.Clients)
                .AddInMemoryIdentityResources(identityServerConfig.IdentityResources)
                .AddInMemoryApiResources(identityServerConfig.Apis)
                .AddInMemoryApiScopes(identityServerConfig.ApiScopes)
                .AddTestUsers(IdentityServerConfiguration.TestUsers.ToList())
                .AddAspNetIdentity<ASUser>();

            services.AddAuthentication();

            if (Env.IsDevelopment())
                isBuilder.AddDeveloperSigningCredential();
            else
                isBuilder.AddSigningCredential(new X509Certificate2("myCert.crt"));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, UserManager<ASUser> userManager, RoleManager<ASRole> roleManager)
        {
            if (Env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            IdentityDataSeeder.SeedData(userManager, roleManager);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
