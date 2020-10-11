using AnimalShelter.Core.Services.Factories;
using AnimalShelter.Core.Services.Utility;
using AnimalShelter.Infrastructure.Common.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Api.ServiceRegistrators
{
    public class FactoryServiceRegistrator : IServiceRegistrator
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IApiLinkFactory, ApiLinkFactory>();
        }
    }
}
