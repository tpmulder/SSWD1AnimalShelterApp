using AnimalShelter.Core.Services.Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace AnimalShelter.Infrastructure.Common.Extensions.Startup
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterAssemblyServices(this IServiceCollection services, IConfiguration configuration, Assembly assembly) =>
            assembly.DefinedTypes
                .Where(x => typeof(IServiceRegistrator)
                .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(e => Expression.Lambda(Expression.New(e.AsType())).Compile().DynamicInvoke())
                .Cast<IServiceRegistrator>()
                .ToList()
                .ForEach(e => e.RegisterAppServices(services, configuration));
    }
}
