using System.Linq.Expressions;
using AppointmentManagement.API.Data;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.API.Repositories;

public class BaseRepository<T>(AppDbContext dbContext) : IBaseRepository<T> where T : class
{
    private readonly DbSet<T> _entitySet = dbContext.Set<T>();
    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
       try 
       {
            await _entitySet.AddAsync(entity, cancellationToken);
       }
       catch(Exception ex)
       {
            throw new Exception(ex.Message);
       }
    }

    public void Remove(T entity, CancellationToken cancellationToken = default)
    {
        _entitySet.Remove(entity);
    }

    public async Task<IEnumerable<T>> GetAllASync(Expression<Func<T, bool>> expression  = null, CancellationToken cancellationToken = default)
    {
        if(expression is null) return await _entitySet.ToListAsync();
        var query = _entitySet.Where(expression);
        return await query.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _entitySet.FindAsync(id);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => {
            _entitySet.Update(entity);
        });
    }
    public async Task SaveChangesAsync() 
    {
        await dbContext.SaveChangesAsync();
    }
}