using UsersAPIService.Models;

namespace UsersAPIService.Repositories
{
    public interface IUserTagsRepository
    {
        public Task<bool> Create(UserTag userTag);

        public Task<List<UserTag>> GetAllUserTags(User user);
        public Task<List<UserTag>> GetAllUserTags(Tag tag);
    }
}
