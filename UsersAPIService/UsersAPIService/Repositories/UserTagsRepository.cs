using Microsoft.EntityFrameworkCore;
using UsersAPIService.Models;

namespace UsersAPIService.Repositories
{
    public class UserTagsRepository : IUserTagsRepository
    {
        private readonly LibManagementDB _context;

        public UserTagsRepository(LibManagementDB context)
        {
            _context = context;
        }

        public async Task<bool> Create(UserTag userTag)
        {
            _context.Users.Attach(userTag.User);
            _context.Tags.Attach(userTag.Tag);
            _context.Add(userTag);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserTag>> GetAllUserTags(User user)
        {
            return await _context.UserTags.
                            Where(userTag => userTag.User.Id == user.Id)
                            .Include(userTag => userTag.User)
                            .Include(userTag => userTag.Tag)
                            .ToListAsync<UserTag>();
        }

        public async Task<List<UserTag>> GetAllUserTags(Tag tag)
        {
            return await _context.UserTags.
                            Where(userTag => userTag.Tag.Id == tag.Id)
                            .Include(userTag => userTag.User)
                            .Include(userTag => userTag.Tag)
                            .ToListAsync<UserTag>();
        }
    }
}
