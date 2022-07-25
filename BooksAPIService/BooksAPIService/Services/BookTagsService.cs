using BooksAPIService.Models;
using BooksAPIService.Repositories;

namespace BooksAPIService.Services
{
    public class BookTagsService : IBookTagsService
    {

        private readonly IBookTagsRepository _bookTagsRepository;
        private readonly IBooksRepository _booksRepository;
        private readonly ITagService _tagService;

        public BookTagsService(IBookTagsRepository bookTagsRepository, IBooksRepository booksRepository, ITagService tagService)
        {
            _bookTagsRepository = bookTagsRepository;
            _booksRepository = booksRepository;
            _tagService = tagService;
        }

        public async Task<object> AddTagForBook(int bookId, int tagId)
        {
            BookTag bookTag = new BookTag();

            Book book = await _booksRepository.GetBookByIdAsync(bookId);

            
            Tag tag = await _tagService.GetTagByIdAsync(tagId);

            bookTag.Book= book;
            bookTag.Tag = tag;
            await _bookTagsRepository.Create(bookTag);
            return new { msg = $"Tag with id #{bookTag.Tag.Id} added for Book id #{bookTag.Book.Id}" };
        }

        public async Task<object> GetBooksOfTag(int tagId)
        {

            Tag tag = await _tagService.GetTagByIdAsync(tagId);

            List<BookTag> bookTags = await _bookTagsRepository.GetAllBookTags(tag);

            var books = from x in bookTags
                        select x.Book;

            return books;
            
        }

        public async Task<object> GetTagsOfBook(int bookId)
        {
            Book book = await _booksRepository.GetBookByIdAsync(bookId);
            List<BookTag> bookTags = await _bookTagsRepository.GetAllBookTags(book);

            var tags = from x in bookTags
                       select x.Tag;

            return tags;
        }
    }
}
