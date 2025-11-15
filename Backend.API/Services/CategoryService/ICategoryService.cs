using Backend.API.Models.Requests;
using Backend.API.Models.Responses;

namespace Backend.API.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryOutDto>> GetAllAsync();
        Task<CategoryOutDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CategoryInDto request);
        Task<bool> UpdateAsync(int id, CategoryInDto request);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<DropdownOutDto>> GetDropdownAsync();
    }
}