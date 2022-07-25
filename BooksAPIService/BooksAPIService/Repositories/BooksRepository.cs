using BooksAPIService.Exceptions;
using BooksAPIService.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksAPIService.Repositories
{
    public class BooksRepository : IBooksRepository
    {

        private readonly LibManagementDB _context;

        public BooksRepository(LibManagementDB context)
        {
            _context = context;
        }

        public async Task<bool> CreateBookAsync(Book book)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync<Book>();
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            var book = await _context.Books.FirstOrDefaultAsync(book => book.Id == bookId);

            if (book == null)
                throw new BookNotFoundException($"Book with id {bookId} not found");

            return book;
        }
    }
}
