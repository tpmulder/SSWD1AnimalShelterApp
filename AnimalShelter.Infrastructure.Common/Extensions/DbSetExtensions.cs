using AnimalShelter.Core.Services.Utility;
using AnimalShelter.Core.Services.Utility.ResourceParams;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Common.Extensions
{
    public static class DbSetExtensions
    {
        public static async Task<IPagedList<T>> GetByParametersWithIncludesAsync<T>(this DbSet<T> source, IPagedResourceParameters parameters)
            where T : class
        {
            var validatedParameters = parameters.Validate<T>();

            IQueryable<T> items = source;

            if (string.IsNullOrEmpty(validatedParameters.Includes))
                items = source.Include(validatedParameters.Includes);

            return await items.GetByParametersAsync(parameters);
        }

        public static async Task<T> GetByParametersWithIncludesAsync<T>(this DbSet<T> source, IResourceParameters parameters)
            where T : class
        {
            var validatedParameters = parameters.Validate<T>();

            IQueryable<T> items = source;

            if (string.IsNullOrEmpty(validatedParameters.Includes))
                items = source.Include(validatedParameters.Includes);

            return await items.GetByParametersAsync(parameters);
        }
    }
}
