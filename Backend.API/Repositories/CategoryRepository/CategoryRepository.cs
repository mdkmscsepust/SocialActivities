using Backend.API.Database;
using Backend.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Category category)
        {
            try
            {
                await _context.AddAsync(category);
                await _context.SaveChangesAsync();
                return true;                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var category = await _context.FindAsync<Category>(id);
                if (category == null) return false;

                _context.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
             try
            {
                return await _context.Set<Category>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Category>().FindAsync(id) ?? null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Category>> GetDropdownAsync()
        {
            try
            {
                return await _context.Set<Category>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            try
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}