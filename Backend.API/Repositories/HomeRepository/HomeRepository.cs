using Backend.API.Database;
using Backend.API.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Repositories.HomeRepository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public HomeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<(int, int, int)> GetCountAsync()
        {
            var countPost = _dbContext.Posts.AsNoTracking().CountAsync();
            var countCategory = _dbContext.Categories.AsNoTracking().CountAsync();
            var countContact = _dbContext.Contacts.AsNoTracking().CountAsync();
            await Task.WhenAll(countPost, countCategory, countContact);
            return (await countPost, await countCategory, await countContact);
        }

        public Task<IEnumerable<PostOutDto>> GetRecentPostsAsync(int itemPerPage)
        {
            throw new NotImplementedException();
        }
    }
}