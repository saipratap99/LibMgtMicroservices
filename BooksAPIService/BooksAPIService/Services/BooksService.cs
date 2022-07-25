using BooksAPIService.Models;
using BooksAPIService.Repositories;

namespace BooksAPIService.Services
{
    public class BooksService : IBooksService
    {

        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<object> CreateBookAsync(Book book)
        {
            await _booksRepository.CreateBookAsync(book);
            return new {msg = $"Book {book.Title} created succefully"};
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _booksRepository.GetAllBooksAsync();
        }

        public async Task<object> GetTagByIdAsync(int bookId)
        {
            return await _booksRepository.GetBookByIdAsync(bookId);
        }

    }
}
