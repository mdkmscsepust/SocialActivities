using Backend.API.Models.Entities;
using Backend.API.Models.Responses;

namespace Backend.API.Services.DonationItemRepository
{
    public interface IDonationItemRepository
    {
        Task<IEnumerable<DonationItemOutDto>> GetAllAsync();
        Task<DonationItemOutDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(DonationItem donationItem);
        Task<bool> UpdateAsync(int id, DonationItem donationItem);
        Task<bool> DeleteAsync(int id);
    }
}