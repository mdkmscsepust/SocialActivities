using Backend.API.Models.Responses;

namespace Backend.API.Services.CommentService
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentOutDto>> GetAllAsync();
        Task<CommentOutDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CommentInDto request);
        Task<bool> UpdateAsync(int id, CommentInDto request);
        Task<bool> DeleteAsync(int id);
    }
}