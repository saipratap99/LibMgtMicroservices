using BooksAPIService.Models;

namespace BooksAPIService.Services
{
    public interface IBookTagsService
    {
        public Task<object> AddTagForBook(int bookId, int tagId);
        public Task<object> GetTagsOfBook(int bookId);
        public Task<object> GetBooksOfTag(int tagId);
    }
}
