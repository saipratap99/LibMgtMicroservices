using BooksAPIService.Models;

namespace BooksAPIService.Repositories
{
    public interface IBooksRepository
    {
        public Task<bool> CreateBookAsync(Book book);

        public Task<List<Book>> GetAllBooksAsync();
        public Task<Book> GetBookByIdAsync(int bookId);
    }
}
