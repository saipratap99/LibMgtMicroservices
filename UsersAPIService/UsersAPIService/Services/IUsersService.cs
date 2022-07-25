using Microsoft.AspNetCore.Mvc;
using UsersAPIService.Models;

namespace UsersAPIService.Services
{
    public interface IUsersService
    {
        public Task<List<User>> GetAllUsersAsync();
        public Task<object> CreateUserAsync(User user);
        public Task<object> AuthenticateUser(AuthenticationRequest authenticationRequest);
    }
}
