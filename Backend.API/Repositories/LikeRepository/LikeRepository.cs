using System.Linq.Expressions;
using Backend.API.Database;
using Backend.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Repositories.LikeRepository
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDbContext _context;

        public LikeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Like Like)
        {
            try
            {
                await _context.AddAsync(Like);
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
                var Like = await _context.FindAsync<Like>(id);
                if (Like == null) return false;

                _context.Remove(Like);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Like>> GetAllAsync()
        {
             try
            {
                return await _context.Set<Like>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        public async Task<Like?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Like>().FindAsync(id) ?? null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(Like Like)
        {
            try
            {
                _context.Update(Like);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<Like, bool>> predicate)
        {
            try
            {
                return await _context.Likes.AnyAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Like?> GetAsync(Expression<Func<Like, bool>> predicate)
        {
            try
            {
                return await _context.Likes.FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<long> CountAsync(Expression<Func<Like, bool>> predicate)
        {
            try
            {
                return await _context.Likes.CountAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}