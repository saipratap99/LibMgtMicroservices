using BooksAPIService.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksAPIService.Repositories
{
    public class BookTagsRepository : IBookTagsRepository
    {

        private readonly LibManagementDB _context;

        public BookTagsRepository(LibManagementDB context)
        {
            _context = context;
        }

        public async Task<bool> Create(BookTag bookTag)
        {
            _context.Books.Attach(bookTag.Book);
            _context.Tags.Attach(bookTag.Tag);
            _context.Add(bookTag);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<BookTag>> GetAllBookTags(Book book)
        {
            return await _context.BookTags.
                            Where(bookTag => bookTag.Book.Id == book.Id)
                            .Include(bookTag => bookTag.Tag)
                            .Include(bookTag => bookTag.Book)
                            .ToListAsync<BookTag>();
        }

        public async Task<List<BookTag>> GetAllBookTags(Tag tag)
        {
            return await _context.BookTags.
                            Where(bookTag => bookTag.Tag.Id == tag.Id)
                            .Include(bookTag => bookTag.Tag)
                            .Include(bookTag => bookTag.Book)
                            .ToListAsync<BookTag>();
        }
    }
}
