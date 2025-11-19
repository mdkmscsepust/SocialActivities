using System.Linq.Expressions;
using Backend.API.Models.Entities;

namespace Backend.API.Repositories.LikeRepository
{
    public interface ILikeRepository
    {
        Task<IEnumerable<Like>> GetAllAsync();
        Task<Like?> GetByIdAsync(int id);
        Task<bool> CreateAsync(Like Like);
        Task<bool> UpdateAsync(Like Like);
        Task<bool> DeleteAsync(int id);
        Task<bool> AnyAsync(Expression<Func<Like, bool>> predicate);
        Task<Like?> GetAsync(Expression<Func<Like, bool>> predicate);
        Task<long> CountAsync(Expression<Func<Like, bool>> predicate);
    }
}