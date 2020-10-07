using AnimalShelter.AuthServer.Configuration;
using AnimalShelter.AuthServer.Configuration.Options;
using AnimalShelter.AuthServer.Data.Contexts;
using AnimalShelter.Core.Constants;
using AnimalShelter.Core.Services.Data;
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

namespace AnimalShelter.AuthServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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

            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString(ConfigurationConstants.AuthDbConnectionString)));

            services.AddIdentity<IdentityUser, IdentityRole>(e => IdentityConfiguration.ConfigureOptions(e, Configuration))
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(e =>
            {
                var controllerName = "Account";

                e.Cookie.Name = "IdentityServer.Cookie";
                e.LoginPath = $"/{controllerName}/Login";
                e.LogoutPath = "/Home/Index";
                e.AccessDeniedPath = $"/{controllerName}/AccesDenied";
            });

            services.AddIdentityServer()
                .AddInMemoryClients(identityServerConfig.Clients)
                .AddInMemoryIdentityResources(identityServerConfig.IdentityResources)
                .AddInMemoryApiResources(identityServerConfig.Apis)
                .AddInMemoryApiScopes(identityServerConfig.ApiScopes)
                .AddTestUsers(IdentityServerConfiguration.TestUsers.ToList())
                .AddAspNetIdentity<IdentityUser>()
                .AddDeveloperSigningCredential();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
