using AnimalShelter.Core.Services.Models;
using AnimalShelter.Core.Services.Utility;
using AnimalShelter.Core.Services.Utility.ResourceParams;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnimalShelter.Core.Services.DataAccess
{
    public interface IDataAccess<T>
        where T : class, IDbModel
    {
        Task<T> GetAsync(IResourceParameters parameters);
        Task<T> GetByIdAsync(Guid id, string includes = "");
        Task<IPagedList<T>> GetPagedAsync(IPagedResourceParameters parameters);

        Task<ICrudResult> CreateAsync(T item, CancellationToken token = default);
        Task<ICrudResult> CreateRangeAsync(IEnumerable<T> items, CancellationToken token = default);

        Task<ICrudResult> DeleteAsync(T item, CancellationToken token = default);
        Task<ICrudResult> DeleteRangeAsync(IEnumerable<T> items, CancellationToken token = default);
        Task<ICrudResult> DeleteByIdAsync(Guid id, CancellationToken token = default);
        Task<ICrudResult> DeleteRangeByIdAsync(IEnumerable<Guid> ids, CancellationToken token = default);

        Task<ICrudResult> UpdateAsync(T item, CancellationToken token = default);
        Task<ICrudResult> UpdateRangeAsync(IEnumerable<T> items, CancellationToken token = default);
    }
}
