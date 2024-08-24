using System.Linq.Expressions;
using Medipro_Patient_Service.Common.Utilities;
using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Application.Interfaces.Repositories;

/// <summary>
/// A Generic repository class that takes type T
/// </summary>
/// <typeparam name="T">represent the entity class</typeparam>
public interface IGenericRepository<T> where T : class
{
   /// <summary>
   /// insert record to the table in the database
   /// </summary>
   /// <param name="entity">receives entity to be inserted</param>
   /// <returns>returns the new entity created</returns>
   Task<T> AddAsync(T entity);
   /// <summary>
   /// insert a range or multiple record in the table.
   /// </summary>
   /// <param name="entities">recieves collection of entities to be inserted in the table</param>
   /// <returns>returns task operation.</returns>
   Task AddRangeAsync(IEnumerable<T> entities);
   /// <summary>
   /// find a certain entity by a given  condition
   /// </summary>
   /// <param name="expression">receives the condition base on what to find the entity,</param>
   /// <param name="isTracking">decides whether to track the changes or not</param>
   /// <returns>returns a queryable data which can later be modified.</returns>
   IQueryable<T?> FindByCondition(Expression<Func<T, bool>> expression, bool isTracking);
   /// <summary>
   /// find a single record from the table
   /// </summary>
   /// <param name="expression">receives the condition base on what to find the entity,</param>
   /// <returns>returns the data if found.</returns>
   Task<T?> FindAsync(Expression<Func<T, bool>> expression);
   /// <summary>
   /// find a entities a include some of their relationship with other entities. 
   /// </summary>
   /// <param name="expression">receives the condition base on what to find the entity,</param>
   /// <param name="includeProperties">receives the property to be included.</param>
   /// <returns>returns entity if found.</returns>
   Task<IEnumerable<T?>> FindAndIncludeAsync(Expression<Func<T, bool>>? expression, params string[] includeProperties);
   /// <summary>
   /// Get all record from the table including some properties if specified.
   /// </summary>
   /// <param name="includeProperties">receives the property to be included.</param>
   /// <returns>returns collection of entities</returns>
   Task<IEnumerable<T?>> GetAllAsync(params string[] includeProperties);
   /// <summary>
   /// Get all record from the table.
   /// </summary>
   /// <returns>returns collection of entities</returns>
   Task<IEnumerable<T?>> GetAllAsync();
   /// <summary>
   /// find record by it Id
   /// </summary>
   /// <param name="id">receives the id on which to find the record.</param>
   /// <returns>returns the record if found.</returns>
   Task<T?> GetByIdAsync(string id);

   /// <summary>
   /// remove record from the table
   /// </summary>
   /// <param name="entity">recieves the entity to be removed.</param>
   /// <returns>returns the number of rows affected by the operation.</returns>
   Task<int> RemoveAsync(T entity);
   /// <summary>
   /// remove range or multiple record from the table.
   /// </summary>
   /// <param name="entities">receives the collection of entities which is to be removed.</param>
   /// <returns>returns the task operation.</returns>
   Task RemoveRangeAsync(IEnumerable<T> entities);
   /// <summary>
   /// update a particular record from the table.
   /// </summary>
   /// <param name="entity">receives the entity to be updated.</param>
   /// <returns>returns the task operation</returns>
   Task UpdateAsync(T entity);
   /// <summary>
   /// gives the number of record present in the table.
   /// </summary>
   /// <param name="expression">receives the condition on which to count.</param>
   /// <returns>returns the number of entity present.</returns>
   Task<int> CountAsync(Expression<Func<T, bool>> expression);
   /// <summary>
   /// gives the number of record present in the table.
   /// </summary>
   /// <returns>returns the number of entity present.</returns>
   Task<int> CountAsync();
   /// <summary>
   /// save changes in the db context.
   /// </summary>
   /// <returns>returns if record is successfully saved.</returns>
   Task<bool> SaveAsync();
   /// <summary>
   /// allow for pageable result of entities.
   /// </summary>
   /// <param name="page">receives the page to be accessed</param>
   /// <param name="pageSize">receives the number of entities to be included in a page.</param>
   /// <param name="filter">decide if result is to be filtered base on conditions.</param>
   /// <param name="orderBy">receives expression on which to order the result.</param>
   /// <param name="includeProperties">receives the property to be included.</param>
   /// <returns>returns a page result.</returns>
   Task<PagedResult<T>> GetPagedResultAsync(int page, int pageSize, Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params string[] includeProperties);
}