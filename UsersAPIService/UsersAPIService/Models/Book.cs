using System.ComponentModel.DataAnnotations;

namespace UsersAPIService.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        [MinLength(2)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author is Required")]
        [MinLength(2)]
        public string Author { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        [MinLength(2)]
        public string Description { get; set; }

    }
}
