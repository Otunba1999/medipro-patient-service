using System.Linq.Expressions;
using Medipro_Patient_Service.Common.Utilities;
using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Application.Interfaces.Repositories;

public interface IGenericRepository<T> where T : Entity
{
   Task<T> AddAsync(T entity);
   Task AddRangeAsync(IEnumerable<T> entities);
   IQueryable<T?> FindByCondition(Expression<Func<T, bool>> expression, bool isTracking);
   Task<T?> FindAsync(Expression<Func<T, bool>> expression);
   Task<IEnumerable<T?>> FindAndIncludeAsync(Expression<Func<T, bool>>? expression, params string[] includeProperties);
   Task<IEnumerable<T?>> GetAllAsync(params string[] includeProperties);
   Task<T?> GetByIdAsync(string id);
   Task<int> RemoveAsync(T entity);
   Task RemoveRangeAsync(IEnumerable<T> entities);
   Task UpdateAsync(T entity);
   Task<int> CountAsync(Expression<Func<T, bool>> expression);
   Task<int> CountAsync();
   Task<bool> SaveAsync();
   Task<PagedResult<T>> GetPagedResultAsync(int page, int pageSize, Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params string[] includePropeeties);
}