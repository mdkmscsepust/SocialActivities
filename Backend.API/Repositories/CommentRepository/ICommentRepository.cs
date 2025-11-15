using Backend.API.Models.Entities;

namespace Backend.API.Repositories.CommentRepository
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<bool> CreateAsync(Comment Comment);
        Task<bool> UpdateAsync(Comment Comment);
        Task<bool> DeleteAsync(int id);
    }
}