using BooksAPIService.Models;

namespace BooksAPIService.Services
{
    public interface ITagService
    {
        public Task<Tag> GetTagByIdAsync(int tagId);
    }
}
