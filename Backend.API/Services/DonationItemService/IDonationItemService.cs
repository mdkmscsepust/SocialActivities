using Backend.API.Models.Entities;
using Backend.API.Models.Responses;

namespace Backend.API.Services.DonationItemService
{
    public interface IDonationItemService
    {
        Task<IEnumerable<DonationItemOutDto>> GetAllDonationItemsAsync();
        Task<DonationItemOutDto?> GetDonationItemByIdAsync(int id);
        Task<bool> CreateDonationItemAsync(DonationItem donationItem);
        Task<bool> UpdateDonationItemAsync(int id, DonationItem donationItem);
        Task<bool> DeleteDonationItemAsync(int id);
    }
}