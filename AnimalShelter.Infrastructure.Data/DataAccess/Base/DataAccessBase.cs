using AnimalShelter.Core.Enums;
using AnimalShelter.Core.Services.Data;
using AnimalShelter.Core.Services.DataAccess;
using AnimalShelter.Core.Services.Models;
using AnimalShelter.Core.Services.Utility;
using AnimalShelter.Core.Services.Utility.ResourceParams;
using AnimalShelter.Infrastructure.Common.Extensions;
using AnimalShelter.Infrastructure.Common.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Data.DataAccess.Base
{
    public abstract class DataAccessBase<T> : IDataAccess<T>
        where T : class, IDbModel
    {
        protected readonly IASDbContext _context;
        protected readonly ILogger<DataAccessBase<T>> _logger;
        protected readonly DbSet<T> _set;

        public DataAccessBase(IASDbContext context, ILogger<DataAccessBase<T>> logger)
        {
            _context = context;
            _set = _context.DbSet<T>();
        }

        public virtual async Task<T> GetAsync(IResourceParameters parameters) =>
            await _set.GetByParametersWithIncludesAsync(parameters);

        public virtual async Task<T> GetByIdAsync(Guid id, string includes = "") =>
            includes.ValidateIncludes<T>(out var validatedIncludes) ? await _set.Include(validatedIncludes).FirstOrDefaultAsync() : await _set.FindAsync(id);

        public virtual async Task<IPagedList<T>> GetPagedAsync(IPagedResourceParameters parameters) =>
            await _set.GetByParametersWithIncludesAsync(parameters);

        public virtual async Task<ICrudResult> CreateAsync(T item, CancellationToken token = default) =>
            await HandleOperationAsync(item, DbOperation.Create, token);

        public virtual async Task<ICrudResult> CreateRangeAsync(IEnumerable<T> items, CancellationToken token = default) =>
            await HandleOperationAsync(items, DbOperation.Create, token);

        public virtual async Task<ICrudResult> DeleteAsync(T item, CancellationToken token = default) =>
            await HandleOperationAsync(item, DbOperation.Delete, token);

        public virtual async Task<ICrudResult> DeleteByIdAsync(Guid id, CancellationToken token = default) =>
            await HandleOperationAsync(id, DbOperation.Delete, token);

        public virtual async Task<ICrudResult> DeleteRangeAsync(IEnumerable<T> items, CancellationToken token = default) =>
            await HandleOperationAsync(items, DbOperation.Delete, token);

        public virtual async Task<ICrudResult> DeleteRangeByIdAsync(IEnumerable<Guid> ids, CancellationToken token = default) =>
            await HandleOperationAsync(ids, DbOperation.Delete, token);

        public virtual async Task<ICrudResult> UpdateAsync(T item, CancellationToken token = default) =>
            await HandleOperationAsync(item, DbOperation.Update, token);

        public virtual async Task<ICrudResult> UpdateRangeAsync(IEnumerable<T> items, CancellationToken token = default) =>
            await HandleOperationAsync(items, DbOperation.Update, token);

        protected virtual async Task<ICrudResult> HandleOperationAsync(IEnumerable<T> items, DbOperation operation, CancellationToken token = default)
        {
            Action action = operation switch
            {
                DbOperation.Create => () => _set.AddRange(items),
                DbOperation.Delete => () => _set.UpdateRange(items),
                DbOperation.Update => () => _set.RemoveRange(items),
                _ => throw new NotImplementedException()
            };

            action.Invoke();

            return new CrudResult<T>(operation, await TrySaveChanges(token), items.Count() > 1);
        }

        protected async Task<ICrudResult> HandleOperationAsync(T item, DbOperation operation, CancellationToken token = default) =>
            await HandleOperationAsync(new[] { item }, operation, token);

        protected async Task<ICrudResult> HandleOperationAsync(Guid id, DbOperation operation, CancellationToken token = default) =>
            await HandleOperationAsync(await _set.FindAsync(id), operation, token);

        protected async Task<ICrudResult> HandleOperationAsync(IEnumerable<Guid> ids, DbOperation operation, CancellationToken token = default) =>
            await HandleOperationAsync(await _set.Where(e => ids.Any(f => e.Id == f)).ToListAsync(), operation, token);

        protected virtual async Task<bool> TrySaveChanges(CancellationToken token = default)
        {
            try
            {
                _logger.LogInformation($"Request successful");

                return Convert.ToBoolean(await _context.SaveChangesAsync(token));
            }
            catch (Exception)
            {
                _logger.LogInformation($"Something went wrong");

                throw;
            }
        }
    }
}
