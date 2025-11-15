using Backend.API.Models.Entities;

namespace Backend.API.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<bool> CreateAsync(Category category);
        Task<bool> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Category>> GetDropdownAsync();
    }
}