using AnimalShelter.Core.Enums;
using AnimalShelter.Core.Services.Utility;
using AnimalShelter.Core.Services.Utility.ResourceParams;
using AnimalShelter.Infrastructure.Common.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Common.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<IPagedList<T>> GetByParametersAsync<T>(this IQueryable<T> source, IPagedResourceParameters parameters)
        {
            var count = source.Count();
            var validatedParameters = parameters.Validate<T>();

            var pageNum = validatedParameters.PageNumber;
            var pageSize = validatedParameters.PageSize;

            var items = source.ApplySearchFilter(validatedParameters.MainCategory, validatedParameters.SearchQuery);

            if (!string.IsNullOrEmpty(validatedParameters.OrderBy))
                items = items.OrderBy(validatedParameters.OrderBy + (validatedParameters.SortOrder == SortOrder.Descending ? " descending" : string.Empty));

            items = items.Skip((pageNum - 1) * pageSize).Take(pageSize);

            return new PagedList<T>(await items.ToListAsync(), count, pageNum, pageSize);
        }

        public static async Task<T> GetByParametersAsync<T>(this IQueryable<T> source, IResourceParameters parameters)
        {
            var validatedParameters = parameters.Validate<T>();

            var items = source.ApplySearchFilter(validatedParameters.MainCategory, validatedParameters.SearchQuery);

            return await items.FirstOrDefaultAsync();
        }

        private static IQueryable<T> ApplySearchFilter<T>(this IQueryable<T> source, string mainCategory, string SearchString) =>
            !(string.IsNullOrEmpty(mainCategory) && string.IsNullOrEmpty(SearchString)) ? source.Where($"{mainCategory} == {SearchString}") : source;
    }
}
