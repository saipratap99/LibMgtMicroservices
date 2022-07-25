using Microsoft.AspNetCore.Mvc;
using UsersAPIService.Models;

namespace UsersAPIService.Repositories
{
    public interface IUsersRepository
    {
        public Task<List<User>> GetAllUsersAsync();
        public Task<object> CreateUserAsync(User user);
        public Task<User> FindByEmailAsync(string email);
        public Task<User> GetUserByIdAsync(int id);
    }
}
