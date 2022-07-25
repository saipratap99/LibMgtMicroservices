using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersAPIService.Exceptions;
using UsersAPIService.Models;

namespace UsersAPIService.Repositories
{
    public class UsersRepository: IUsersRepository
    {

        private readonly LibManagementDB _context;

        public UsersRepository(LibManagementDB context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync<User>();
        }

        public async Task<object> CreateUserAsync(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return new { msg = $"User {user.Name} added successfully" };
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var user =  await _context.Users.FirstOrDefaultAsync(user => user.Email.Equals(email));

            if (user == null)
                throw new UserNotFoundException($"User not found with email {email}");

            return user;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);

            if (user == null)
                throw new UserNotFoundException($"User not found with id {id}");

            return user;
        }
    }
}
