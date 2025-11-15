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
    }
}