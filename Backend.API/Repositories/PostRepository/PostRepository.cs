using Backend.API.Database;
using Backend.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Repositories.PostRepository
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Post Post)
        {
            try
            {
                await _context.AddAsync(Post);
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
                var Post = await _context.FindAsync<Post>(id);
                if (Post == null) return false;

                _context.Remove(Post);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            try
            {
                return await _context.Set<Post>().Include(x => x.Category).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Post>().FindAsync(id) ?? null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Post>> GetDropdownAsync()
        {
            try
            {
                return await _context.Set<Post>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(Post Post)
        {
            try
            {
                _context.Update(Post);
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