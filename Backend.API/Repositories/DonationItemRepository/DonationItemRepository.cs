using Backend.API.Database;
using Backend.API.Models.Entities;
using Backend.API.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Services.DonationItemRepository
{
    public class DonationItemRepository : IDonationItemRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public DonationItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateAsync(DonationItem donationItem)
        {
            try
            {
                var item = await _dbContext.DonationItems.AddAsync(donationItem);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while creating the donation item.", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try 
            {
                var item = await _dbContext.DonationItems.FindAsync(id);
                if (item == null)
                {
                    return false;
                }
                _dbContext.DonationItems.Remove(item);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while deleting the donation item.", ex);
            }
        }

        public async Task<IEnumerable<DonationItemOutDto>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Set<DonationItem>().AsNoTracking().Select(x => new DonationItemOutDto
                {
                     CategoryId = x.CategoryId,
                     DonationId = x.DonationId,
                     Type = x.Type,
                     Description = x.Description,
                     Level = x.Level,
                     Subject = x.Subject,
                     Version = x.Version,
                     Author = x.Author,
                     Condition = x.Condition,
                     Quantity = x.Quantity,
                     Status = x.Status,
                     Notes = x.Notes,
                     Id = x.Id,
                     CreatedAt = x.CreatedAt,
                     UpdatedAt = x.UpdatedAt
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving donation items.", ex);
            }
        }

        public async Task<DonationItemOutDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _dbContext
                    .Set<DonationItem>()
                    .AsNoTracking()
                    .Where(x => x.Id == id)
                    .Select(x => new DonationItemOutDto
                    {
                        CategoryId = x.CategoryId,
                        DonationId = x.DonationId,
                        Type = x.Type,
                        Description = x.Description,
                        Level = x.Level,
                        Subject = x.Subject,
                        Version = x.Version,
                        Author = x.Author,
                        Condition = x.Condition,
                        Quantity = x.Quantity,
                        Status = x.Status,
                        Notes = x.Notes,
                        Id = x.Id,
                        CreatedAt = x.CreatedAt,
                        UpdatedAt = x.UpdatedAt
                    })
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the donation item.", ex);
            }
        }

        public async Task<bool> UpdateAsync(int id, DonationItem donationItem)
        {
            try
            {
                var existingItem = await _dbContext.DonationItems.FindAsync(id);
                if (existingItem is null)
                {
                    return false;
                }

                _dbContext.Entry(existingItem).CurrentValues.SetValues(donationItem);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while updating the donation item.", ex);
            }
        }
    }
}