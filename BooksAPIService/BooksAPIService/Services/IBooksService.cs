using BooksAPIService.Models;

namespace BooksAPIService.Services
{
    public interface IBooksService
    {
        public Task<object> CreateBookAsync(Book book);

        public Task<List<Book>> GetAllBooksAsync();
        Task<object?> GetTagByIdAsync(int bookId);
    }
}
