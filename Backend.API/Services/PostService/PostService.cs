using Backend.API.Models.Entities;
using Backend.API.Models.Requests;
using Backend.API.Models.Responses;
using Backend.API.Repositories.LikeRepository;
using Backend.API.Repositories.PostRepository;
using Mapster;

namespace Backend.API.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ILikeRepository _likeRepository;

        public PostService(IPostRepository postRepository, ILikeRepository likeRepository)
        {
            _postRepository = postRepository;
            _likeRepository = likeRepository;
        }

        public async Task<bool> CreateAsync(PostInDto request) =>
            await _postRepository.CreateAsync(request.Adapt<Post>());

        public async Task<bool> DeleteAsync(int id) =>
            await _postRepository.DeleteAsync(id);

        public async Task<IEnumerable<PostOutDto>> GetAllAsync() {
            var list = await _postRepository.GetAllAsync();
            var postOutDto = list.Adapt<IEnumerable<PostOutDto>>();
            //foreach(var item in postOutDto)
            //{
                if(list.Any(x => list.Any(x => x.Likes.Any(x => x.UserId == 1))));
                //item.lipostOutDto 
            //}
            // postOutDto.LikeCount = post.Likes.Count();
            // var likes = _likeRepository.GetAsync(x => x.PostId == post.Likes.)
            return list.Adapt<IEnumerable<PostOutDto>>();
        }

        public async Task<PostOutDto?> GetByIdAsync(int id)
        {
            var post =  await _postRepository.GetByIdAsync(id);
            var postOutDto = post?.Adapt<PostOutDto>();
            // postOutDto.LikeCount = post.Likes.Count();
            // var likes = _likeRepository.GetAsync(x => x.PostId == post.Likes.)
            return postOutDto;
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