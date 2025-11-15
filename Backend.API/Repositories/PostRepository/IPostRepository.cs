using Backend.API.Models.Entities;

namespace Backend.API.Repositories.PostRepository
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post?> GetByIdAsync(int id);
        Task<bool> CreateAsync(Post category);
        Task<bool> UpdateAsync(Post category);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Post>> GetDropdownAsync();
    }
}