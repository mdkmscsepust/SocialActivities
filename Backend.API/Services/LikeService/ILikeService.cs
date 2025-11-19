using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.API.Models.Requests;
using Backend.API.Models.Responses;

namespace Backend.API.Services.LikeService
{
    public interface ILikeService
    {
        Task<IEnumerable<LikeOutDto>> GetAllAsync();
        Task<LikeOutDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(LikeInDto request);
        Task<bool> UpdateAsync(int id, LikeInDto request);
        Task<bool> DeleteAsync(int id);
        Task<ToggleLikedOutDto> ToggleLiked(int postId);
    }
}