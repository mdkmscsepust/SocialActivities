using Backend.API.Models.Requests;
using Backend.API.Models.Responses;

namespace Backend.API.Services.ContactService
{
    public interface IContactService
    {
        Task<IEnumerable<ContactOutDto>> GetAllAsync();
        Task<ContactOutDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(ContactInDto request);
        Task<bool> UpdateAsync(int id, ContactInDto request);
        Task<bool> DeleteAsync(int id);
    }
}