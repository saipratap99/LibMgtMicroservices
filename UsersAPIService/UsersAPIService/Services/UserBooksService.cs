using UsersAPIService.Models;
using UsersAPIService.Repositories;

namespace UsersAPIService.Services
{
    public class UserBooksService : IUserBooksService
    {

        private readonly IUsersRepository _usersRepository;
        private readonly IConfiguration _configuration;
        private readonly IUserTagsRepository _userTagsRepository;
        private readonly IBooksService _booksService;

        public UserBooksService(IUsersRepository usersRepository,
                            IConfiguration configuration,
                            IUserTagsRepository userTagsRepository,
                            IBooksService booksService)
        {
            _usersRepository = usersRepository;
            _configuration = configuration;
            _userTagsRepository = userTagsRepository;
            _booksService = booksService;
        }

        public async Task<List<Book>> GetBooksForUser(int userId)
        {
            User user = await _usersRepository.GetUserByIdAsync(userId);

            List<Book> books = new List<Book>();

            List<UserTag> userTags = await _userTagsRepository.GetAllUserTags(user);

            var tags = from userTag in userTags
                             select userTag.Tag;

            foreach(var tag in tags)
            {
                var booksList = await _booksService.GetBooksForTag(tag.Id);
                booksList.ForEach(book => books.Add(book));
            }

            return books;
        }
    }
}
