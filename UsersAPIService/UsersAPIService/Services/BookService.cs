using UsersAPIService.Models;

namespace UsersAPIService.Services
{
    public class BookService : IBooksService
    {

        private readonly IConfiguration _configuration;

        public BookService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Book>> GetBooksForTag(int tagId)
        {
            Console.WriteLine("***************************************");
            Console.WriteLine(_configuration.GetSection("BooksAPIService").Value);

            List<Book> books = new List<Book>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{_configuration.GetSection("BooksAPIService").Value}");

            var resp = await client.GetAsync($"/api/v1/book-tags/Get/tag/{tagId}");

            if (resp.IsSuccessStatusCode && resp.Content != null)
            {
                books = await resp.Content.ReadFromJsonAsync<List<Book>>();
            }
            else
                throw new Exception(await resp.Content.ReadAsStringAsync());

            if (books == null)
                throw new Exception("Books list is null");
            return books;
        }
    }
}
