using UsersAPIService.Models;

namespace UsersAPIService.Services
{
    public interface IBooksService
    {
        public Task<List<Book>> GetBooksForTag(int tagId);
    }
}
