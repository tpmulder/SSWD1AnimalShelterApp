using AnimalShelter.Core.Constants;
using AnimalShelter.Core.Services.Data;
using AnimalShelter.Core.Services.Utility;
using AnimalShelter.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalShelter.Api.ServiceRegistrators
{
    public class DataServiceRegistrator : IServiceRegistrator
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IASDbContext, ASDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString(ConfigurationConstants.ASDbConnectionString)));
        }
    }
}
