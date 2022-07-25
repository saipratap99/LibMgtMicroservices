using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TagsAPIService.Models;
using TagsAPIService.Services;

namespace TagsAPIService.Controllers
{
    [ApiController]
    [Route("/api/v1/Tags")]
    public class TagsController : ControllerBase
    {

        private readonly ITagsService _tagsService;

        public TagsController(ITagsService tagsService)
        {
            _tagsService = tagsService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Tag>>> Index()
        {
            return Ok(await _tagsService.GetAllTagsAsync());
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<ActionResult<List<Tag>>> Create(Tag tag)
        {
            return Ok(await _tagsService.CreateTagAsync(tag));
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public async Task<ActionResult<List<Tag>>> Get(int id)
        {
            return Ok(await _tagsService.GetTagByIdAsync(id));
        }
    }
}
