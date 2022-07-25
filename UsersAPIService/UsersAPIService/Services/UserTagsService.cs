using UsersAPIService.Models;
using UsersAPIService.Repositories;

namespace UsersAPIService.Services
{
    public class UserTagsService : IUserTagsService
    {

        private readonly IUserTagsRepository _userTagsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly ITagsService _tagsService;

        public UserTagsService(IUserTagsRepository userTagsRepository, IUsersRepository usersRepository, ITagsService tagsService)
        {
            _userTagsRepository = userTagsRepository;
            _usersRepository = usersRepository;
            _tagsService = tagsService;
        }

        public async Task<object> AddTagForUser(int userId, int tagId)
        {
            UserTag userTag = new UserTag();
            
            User user = await _usersRepository.GetUserByIdAsync(userId);

            // get tag from TagsAPIService
            Tag tag = await _tagsService.GetTagByIdAsync(tagId);

            userTag.User = user;
            userTag.Tag = tag;
            await _userTagsRepository.Create(userTag);
            return new { msg = $"Tag with id #{userTag.Tag.Id} added for user id #{userTag.User.Id}" };
        }

        public async Task<object> GetTagsOfUser(int userId)
        {
            User user = await _usersRepository.GetUserByIdAsync(userId);
            List<UserTag> userTags = await _userTagsRepository.GetAllUserTags(user);

            var tags = from x in userTags
                       select x.Tag;

            return tags;
        }

        public async Task<object> GetUsersOfTag(int tagId)
        {
            Tag tag = await _tagsService.GetTagByIdAsync(tagId);

            List<UserTag> userTags  = await _userTagsRepository.GetAllUserTags(tag);

            var users = from x in userTags
                        select x.User;

            return users;
        }
    }
}
