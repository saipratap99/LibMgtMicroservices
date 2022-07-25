using UsersAPIService.Models;

namespace UsersAPIService.Services
{
    public class TagsService : ITagsService
    {

        private readonly IConfiguration _configuration;

        public TagsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Tag> GetTagByIdAsync(int tagId)
        {
            Tag tag;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{_configuration.GetSection("TagsAPIService").Value}");

            var resp = await client.GetAsync($"/api/v1/Tags/get/{tagId}");

            if (resp.IsSuccessStatusCode && resp.Content != null)
            {
                tag = await resp.Content.ReadFromJsonAsync<Tag>();
            }
            else
                throw new Exception(await resp.Content.ReadAsStringAsync());

            if (tag == null)
                throw new Exception("Tag is null");
            return tag;
        }
    }
}
