using TagsAPIService.Models;

namespace TagsAPIService.Services
{
    public interface ITagsService
    {
        public Task<List<Tag>> GetAllTagsAsync();
        public Task<object> CreateTagAsync(Tag tag);
        public Task<Tag> GetTagByIdAsync(int id);
    }
}
