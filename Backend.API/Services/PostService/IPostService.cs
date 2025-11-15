using Backend.API.Models.Requests;
using Backend.API.Models.Responses;

namespace Backend.API.Services.PostService
{
    public interface IPostService
    {
        Task<IEnumerable<PostOutDto>> GetAllAsync();
        Task<PostOutDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(PostInDto request);
        Task<bool> UpdateAsync(int id, PostInDto request);
        Task<bool> DeleteAsync(int id);
    }
}