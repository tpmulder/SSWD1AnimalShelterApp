using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Services.Utility
{
    public interface IServiceRegistrator
    {
        void RegisterAppServices(IServiceCollection services, IConfiguration configuration);
    }
}
