using Microsoft.EntityFrameworkCore;
using TagsAPIService.Exceptions;
using TagsAPIService.Models;

namespace TagsAPIService.Repositories
{
    public class TagsRepository : ITagsRepository
    {

        private readonly LibManagementDB _context;

        public TagsRepository(LibManagementDB context)
        {
            _context = context;
        }

        public async Task<bool> CreateTagAsync(Tag tag)
        {
            _context.Add(tag);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Tag>> GetAllTagsAsync()
        {
            return await _context.Tags.ToListAsync<Tag>();
        }

        public async Task<Tag> GetTagAsync(int id)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(tag => tag.Id == id);
            
            if (tag == null)
                throw new TagNotFoundException($"Tag with id {id} not found");

            return tag;
        }
    }
}
