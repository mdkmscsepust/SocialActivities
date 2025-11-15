using Backend.API.Models;
using Backend.API.Models.Entities;
using Backend.API.Models.Requests;
using Backend.API.Models.Responses;
using Backend.API.Repositories.CategoryRepository;
using Mapster;

namespace Backend.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> CreateAsync(CategoryInDto request) =>
            await _categoryRepository.CreateAsync(request.Adapt<Category>());

        public async Task<bool> DeleteAsync(int id) =>
            await _categoryRepository.DeleteAsync(id);

        public async Task<IEnumerable<CategoryOutDto>> GetAllAsync() {
            var list = await _categoryRepository.GetAllAsync();
            return list.Adapt<IEnumerable<CategoryOutDto>>();
        }

        public async Task<CategoryOutDto?> GetByIdAsync(int id)
        {
            var category =  await _categoryRepository.GetByIdAsync(id);
            return category?.Adapt<CategoryOutDto>();
        }

        public async Task<IEnumerable<DropdownOutDto>> GetDropdownAsync()
        {
            var list = await _categoryRepository.GetDropdownAsync();
            return list.Adapt<IEnumerable<DropdownOutDto>>();
        }

        public async Task<bool> UpdateAsync(int id, CategoryInDto request)
        {
            var checkExists = await _categoryRepository.GetByIdAsync(id);
            if (checkExists == null) return false;  

            checkExists.Name = request.Name;
            return await _categoryRepository.UpdateAsync(checkExists);            
        }
    }
}