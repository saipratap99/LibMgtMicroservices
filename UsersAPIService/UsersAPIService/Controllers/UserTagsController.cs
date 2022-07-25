using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersAPIService.Models;
using UsersAPIService.Services;

namespace UsersAPIService.Controllers
{
    [Route("api/v1/user-tags")]
    [ApiController]
    public class UserTagsController : ControllerBase
    {

        private readonly IUserTagsService _userTagsService;

        public UserTagsController(IUserTagsService userTagsService)
        {
            _userTagsService = userTagsService;
        }

        [HttpPost]
        [Route("[Action]/user/{userId}/tag/{tagId}")]
        public async Task<ActionResult<object>> Create(int userId, int tagId)
        {
            return Ok(await _userTagsService.AddTagForUser(userId, tagId));
        }

        [HttpGet]
        [Route("[Action]/user/{userId}")]
        public async Task<ActionResult<List<UserTag>>> Get(int userId)
        {
            return Ok(await _userTagsService.GetTagsOfUser(userId));
        }

        [HttpGet]
        [Route("Get/tag/{tagId}")]
        public async Task<ActionResult<List<User>>> GetUsersForTag(int tagId)
        {
            return Ok(await _userTagsService.GetUsersOfTag(tagId));
        }


    }
}
