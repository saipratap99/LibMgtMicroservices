using UsersAPIService.Models;

namespace UsersAPIService.Services
{
    public interface IUserBooksService
    {
        public Task<List<Book>> GetBooksForUser(int userId);
    }
}
