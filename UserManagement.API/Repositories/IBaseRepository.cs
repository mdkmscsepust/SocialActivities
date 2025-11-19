using System.Linq.Expressions;

namespace AppointmentManagement.API.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Remove(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetAllASync(Expression<Func<TEntity,bool>> expression = null, CancellationToken cancellationToken = default);
   Task SaveChangesAsync();
}