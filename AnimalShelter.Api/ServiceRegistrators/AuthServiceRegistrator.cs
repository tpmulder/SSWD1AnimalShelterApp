using AnimalShelter.Core.Services.Utility;
using AnimalShelter.Infrastructure.Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Api.ServiceRegistrators
{
    public class AuthServiceRegistrator : IServiceRegistrator
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            var identityServerUrl = configuration.GetSection("IdentityServer:Url").Value;

            var apiSettings = configuration.GetSection(ApiSettings.Section)
                .Get<ApiSettings>();

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = identityServerUrl;
                    options.Audience = apiSettings.Name;
                });
        }
    }
}
