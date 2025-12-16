using Backend.API.Models.Responses;

namespace Backend.API.Repositories.HomeRepository
{
    public interface IHomeRepository
    {
        Task<(int,int,int)> GetCountAsync();
        Task<IEnumerable<PostOutDto>> GetRecentPostsAsync(int itemPerPage);
    }
}