using BooksAPIService.Models;
using BooksAPIService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPIService.Controllers
{
    [Route("api/v1/book-tags")]
    [ApiController]
    public class BookTagsController : ControllerBase
    {

        private readonly IBookTagsService _bookTagsService;

        public BookTagsController(IBookTagsService bookTagsService)
        {
            _bookTagsService = bookTagsService;
        }

        [HttpPost]
        [Route("[Action]/book/{bookId}/tag/{tagId}")]
        public async Task<ActionResult<object>> Create(int bookId, int tagId)
        {
            return Ok(await _bookTagsService.AddTagForBook(bookId, tagId));
        }

        [HttpGet]
        [Route("[Action]/book/{bookId}")]
        public async Task<ActionResult<List<Tag>>> Get(int bookId)
        {
            return Ok(await _bookTagsService.GetTagsOfBook(bookId));
        }

        [HttpGet]
        [Route("Get/tag/{tagId}")]
        public async Task<ActionResult<List<Book>>> GetBooksForTag(int tagId)
        {
            return Ok(await _bookTagsService.GetBooksOfTag(tagId));
        }

    }
}
