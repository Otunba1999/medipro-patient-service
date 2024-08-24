using System.Linq.Expressions;
using medipro_patient_service.Application.Interfaces.Repositories;
using Medipro_Patient_Service.Common.Utilities;
using medipro_patient_service.Domain.Models;
using medipro_patient_service.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace medipro_patient_service.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public IQueryable<T?> FindByCondition(Expression<Func<T, bool>> expression, bool isTracking) =>
        !isTracking ? _dbSet.Where(expression).AsNoTracking() : _dbSet.Where(expression);
    
    public async Task<T?> FindAsync(Expression<Func<T, bool>> expression) =>
        await _dbSet.FirstOrDefaultAsync(expression);
    
    public async Task<IEnumerable<T?>> FindAndIncludeAsync(Expression<Func<T, bool>>? expression,
        params string[] includeProperties)
    {
        IQueryable<T> query = _dbSet;
        if (expression is not null) query = query.Where(expression);
        
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<T?>> GetAllAsync(params string[] includeProperties)
    {
        IQueryable<T> query = _dbSet;
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<T?>> GetAllAsync()
    {
        IQueryable<T> query = _dbSet;
        return await query.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(string id) => await _dbSet.FindAsync(id);
    

    public Task<int> RemoveAsync(T entity)
    {
        _dbSet.Remove(entity);
         _context.SaveChanges();
        return (Task<int>)Task.CompletedTask;
    }

    public Task RemoveRangeAsync(IEnumerable<T> entities)
    {
       _dbSet.RemoveRange(entities); 
       _context.SaveChanges();
       return Task.CompletedTask;
    }

    public Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        // await _context.SaveChangesAsync();
        return Task.CompletedTask; 
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> expression) => await _dbSet.CountAsync(expression);

    public async Task<int> CountAsync() => await _dbSet.CountAsync();

    public  async Task<bool> SaveAsync() => await _context.SaveChangesAsync() > 0;
    
    public async Task<PagedResult<T>> GetPagedResultAsync(int page, int pageSize, Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        params string[] includeProperties)
    {
        IQueryable<T> query = _dbSet;
        if (filter is not null) query = query.Where(filter);
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        if (orderBy is not null) query = orderBy(query);

        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PagedResult<T>()
        {
            CurrentPage = page,
            PageSize = pageSize,
            Items = items,
            TotalCount = totalCount,
            TotalPages = totalPages
        };
    }
}