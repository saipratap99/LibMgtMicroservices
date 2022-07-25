using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersAPIService.Models;
using UsersAPIService.Services;

namespace UsersAPIService.Controllers
{
    [Route("api/v1/user-books")]
    [ApiController]
    public class UserBooksController : ControllerBase
    {

        private readonly IUserBooksService _userBooksService;

        public UserBooksController(IUserBooksService userBooksService)
        {
            _userBooksService = userBooksService;
        }

        [HttpGet]
        [Route("[Action]/{userId}")]
        public async Task<ActionResult<List<Book>>> Get(int userId)
        {
            return Ok(await _userBooksService.GetBooksForUser(userId));
        }
    }
}
