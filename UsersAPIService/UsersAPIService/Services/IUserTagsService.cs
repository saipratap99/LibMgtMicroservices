using Microsoft.AspNetCore.Mvc;
using UsersAPIService.Models;

namespace UsersAPIService.Services
{
    public interface IUserTagsService
    {
        public Task<object> AddTagForUser(int userId, int tagId);
        public Task<object> GetTagsOfUser(int userId);
        public Task<object> GetUsersOfTag(int tagId);
    }
}
