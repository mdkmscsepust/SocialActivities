using Backend.API.Models.Entities;
using Backend.API.Models.Responses;
using Backend.API.Repositories.CommentRepository;
using Mapster;

namespace Backend.API.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<bool> CreateAsync(CommentInDto request) =>
            await _commentRepository.CreateAsync(request.Adapt<Comment>());

        public async Task<bool> DeleteAsync(int id) =>
            await _commentRepository.DeleteAsync(id);

        public async Task<IEnumerable<CommentOutDto>> GetAllAsync() {
            var list = await _commentRepository.GetAllAsync();
            return list.Adapt<IEnumerable<CommentOutDto>>();
        }

        public async Task<CommentOutDto?> GetByIdAsync(int id)
        {
            var Comment =  await _commentRepository.GetByIdAsync(id);
            return Comment?.Adapt<CommentOutDto>();
        }

        public async Task<bool> UpdateAsync(int id, CommentInDto request)
        {
            var checkExists = await _commentRepository.GetByIdAsync(id);
            if (checkExists == null) return false;  

            checkExists.PostId = request.PostId;
            checkExists.UserId = request.UserId;
            checkExists.Content = request.Content;
            return await _commentRepository.UpdateAsync(checkExists);            
        }
    }
}