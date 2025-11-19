using Backend.API.Models.Entities;
using Backend.API.Models.Requests;
using Backend.API.Models.Responses;
using Backend.API.Repositories.LikeRepository;
using Mapster;

namespace Backend.API.Services.LikeService
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<bool> CreateAsync(LikeInDto request) =>
            await _likeRepository.CreateAsync(request.Adapt<Like>());

        public async Task<bool> DeleteAsync(int id) =>
            await _likeRepository.DeleteAsync(id);

        public async Task<IEnumerable<LikeOutDto>> GetAllAsync() {
            var list = await _likeRepository.GetAllAsync();
            return list.Adapt<IEnumerable<LikeOutDto>>();
        }

        public async Task<LikeOutDto?> GetByIdAsync(int id)
        {
            var Like =  await _likeRepository.GetByIdAsync(id);
            return Like?.Adapt<LikeOutDto>();
        }

        public async Task<bool> UpdateAsync(int id, LikeInDto request)
        {
            var checkExists = await _likeRepository.GetByIdAsync(id);
            if (checkExists == null) return false;  

            checkExists.PostId = request.PostId;
            checkExists.UserId = request.UserId;
            return await _likeRepository.UpdateAsync(checkExists);            
        }

        public async Task<ToggleLikedOutDto> ToggleLiked(int postId)
        {
            var isLikeExist = await _likeRepository.GetAsync(x => x.PostId == postId && x.UserId == 1);
            var toggleLikedOutDto = new ToggleLikedOutDto();
            if( isLikeExist is not null)
            {
                await _likeRepository.DeleteAsync(isLikeExist.Id);
                toggleLikedOutDto.IsLiked = false;

            } else
            {
                await _likeRepository.CreateAsync(new Like
                {
                    PostId = postId,
                    UserId = 1
                });

                toggleLikedOutDto.IsLiked = true;
            }

            toggleLikedOutDto.LikedCount = await _likeRepository.CountAsync(x => x.PostId == postId);
            
            return toggleLikedOutDto;
        }
    }
}