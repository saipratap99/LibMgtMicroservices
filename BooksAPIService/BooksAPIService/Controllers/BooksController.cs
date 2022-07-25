using BooksAPIService.Models;
using BooksAPIService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPIService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Book>>> Index()
        {
            return Ok(await _booksService.GetAllBooksAsync());
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<ActionResult<object>> Create(Book book)
        {
            return Ok(await _booksService.CreateBookAsync(book));
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            return Ok(await _booksService.GetTagByIdAsync(id));
        }
    }
}
