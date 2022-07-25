using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersAPIService.Authentication;
using UsersAPIService.Models;
using UsersAPIService.Services;

namespace UsersAPIService.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {

        private readonly IUsersService _usersService;
        
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<User>>> Index()
        {
            return Ok(await _usersService.GetAllUsersAsync());
        }


        [HttpPost]
        [Route("[Action]")]
        public async Task<ActionResult<Object>> Create(User user)
        {
            return ModelState.IsValid ? Ok(await _usersService.CreateUserAsync(user)) : BadRequest();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("[Action]")]
        public async Task<ActionResult<Object>> Login(AuthenticationRequest authenticationRequest)
        {
            return Ok(await _usersService.AuthenticateUser(authenticationRequest));
        }

    }
}
