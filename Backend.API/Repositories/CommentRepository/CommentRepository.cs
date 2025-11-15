using Backend.API.Database;
using Backend.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Repositories.CommentRepository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Comment Comment)
        {
            try
            {
                await _context.AddAsync(Comment);
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
                var Comment = await _context.FindAsync<Comment>(id);
                if (Comment == null) return false;

                _context.Remove(Comment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
             try
            {
                return await _context.Set<Comment>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Comment>().FindAsync(id) ?? null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(Comment Comment)
        {
            try
            {
                _context.Update(Comment);
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