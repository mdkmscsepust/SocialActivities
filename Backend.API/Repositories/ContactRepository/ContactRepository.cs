using Backend.API.Database;
using Backend.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Repositories.ContactRepository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Contact Contact)
        {
            try
            {
                await _context.AddAsync(Contact);
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
                var Contact = await _context.FindAsync<Contact>(id);
                if (Contact == null) return false;

                _context.Remove(Contact);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
             try
            {
                return await _context.Set<Contact>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        public async Task<Contact?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Contact>().FindAsync(id) ?? null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Contact>> GetDropdownAsync()
        {
            try
            {
                return await _context.Set<Contact>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(Contact Contact)
        {
            try
            {
                _context.Update(Contact);
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