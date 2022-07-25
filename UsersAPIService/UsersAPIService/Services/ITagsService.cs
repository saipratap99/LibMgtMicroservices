using UsersAPIService.Models;

namespace UsersAPIService.Services
{
    public interface ITagsService
    {
        public Task<Tag> GetTagByIdAsync(int tagId);
    }
}
