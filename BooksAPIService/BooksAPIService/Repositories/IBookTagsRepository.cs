using BooksAPIService.Models;

namespace BooksAPIService.Repositories
{
    public interface IBookTagsRepository
    {
        public Task<bool> Create(BookTag bookTag);
        public Task<List<BookTag>> GetAllBookTags(Book book);
        public Task<List<BookTag>> GetAllBookTags(Tag tag);
    }
}
