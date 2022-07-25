using TagsAPIService.Models;
using TagsAPIService.Repositories;

namespace TagsAPIService.Services
{
    public class TagsService : ITagsService
    {

        private readonly ITagsRepository _tagsRepository;

        public TagsService(ITagsRepository tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }

        public async Task<object> CreateTagAsync(Tag tag)
        {
            await _tagsRepository.CreateTagAsync(tag);
            return new { msg = $"Tag {tag.Name} created successfully" };
        }

        public async Task<List<Tag>> GetAllTagsAsync()
        {
            return await _tagsRepository.GetAllTagsAsync();
        }

        public async Task<Tag> GetTagByIdAsync(int id)
        {
            return await _tagsRepository.GetTagAsync(id);
        }
    }
}
