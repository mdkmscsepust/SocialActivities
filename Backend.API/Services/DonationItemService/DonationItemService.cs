using Backend.API.Models.Entities;
using Backend.API.Models.Responses;
using Backend.API.Services.DonationItemRepository;

namespace Backend.API.Services.DonationItemService
{
    public class DonationItemService : IDonationItemService
    {
        private readonly IDonationItemRepository _donationItemRepository;

        public DonationItemService(IDonationItemRepository donationItemRepository)
        {
            _donationItemRepository = donationItemRepository;
        }

        public async Task<bool> CreateDonationItemAsync(DonationItem donationItem) => await _donationItemRepository.CreateAsync(donationItem);

        public async Task<bool> DeleteDonationItemAsync(int id) => await _donationItemRepository.DeleteAsync(id);

        public async Task<IEnumerable<DonationItemOutDto>> GetAllDonationItemsAsync() => await _donationItemRepository.GetAllAsync();

        public async Task<DonationItemOutDto?> GetDonationItemByIdAsync(int id) =>  await _donationItemRepository.GetByIdAsync(id);

        public async Task<bool> UpdateDonationItemAsync(int id, DonationItem donationItem) => await _donationItemRepository.UpdateAsync(id, donationItem);
    }
}