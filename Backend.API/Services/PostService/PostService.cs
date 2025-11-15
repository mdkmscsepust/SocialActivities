using Backend.API.Models.Entities;
using Backend.API.Models.Requests;
using Backend.API.Models.Responses;
using Backend.API.Repositories.PostRepository;
using Mapster;

namespace Backend.API.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<bool> CreateAsync(PostInDto request) =>
            await _postRepository.CreateAsync(request.Adapt<Post>());

        public async Task<bool> DeleteAsync(int id) =>
            await _postRepository.DeleteAsync(id);

        public async Task<IEnumerable<PostOutDto>> GetAllAsync() {
            var list = await _postRepository.GetAllAsync();
            return list.Adapt<IEnumerable<PostOutDto>>();
        }

        public async Task<PostOutDto?> GetByIdAsync(int id)
        {
            var Post =  await _postRepository.GetByIdAsync(id);
            return Post?.Adapt<PostOutDto>();
        }

        public async Task<IEnumerable<DropdownOutDto>> GetDropdownAsync()
        {
            var list = await _postRepository.GetDropdownAsync();
            return list.Adapt<IEnumerable<DropdownOutDto>>();
        }

        public async Task<bool> UpdateAsync(int id, PostInDto request)
        {
            var checkExists = await _postRepository.GetByIdAsync(id);
            if (checkExists == null) return false;  

            checkExists.Tag = request.Tag;
            checkExists.Title = request.Title;
            checkExists.Description = request.Description;
            checkExists.Location = request.Location;
            checkExists.CategoryId = request.CategoryId;
            return await _postRepository.UpdateAsync(checkExists);            
        }
    }
}