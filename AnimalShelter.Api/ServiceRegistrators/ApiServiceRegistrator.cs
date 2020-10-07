using AnimalShelter.Core.Services.Session;
using AnimalShelter.Core.Services.Utility;
using AnimalShelter.Infrastructure.Common.Wrappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Api.ServiceRegistrators
{
    public class ApiServiceRegistrator : IServiceRegistrator
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserSession, ASUserSession>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AnimalShelter.Api", Version = "v1" });
            });
        }
    }
}
