using TagsAPIService.Models;

namespace TagsAPIService.Repositories
{
    public interface ITagsRepository
    {
       public Task<List<Tag>> GetAllTagsAsync();
       public Task<bool> CreateTagAsync(Tag tag);
       public Task<Tag> GetTagAsync(int id);

    }
}
