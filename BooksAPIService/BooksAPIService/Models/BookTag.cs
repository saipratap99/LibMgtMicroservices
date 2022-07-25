using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAPIService.Models
{
    public class BookTag
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("BookId")]
        [Required(ErrorMessage = "Book is required")]
        public Book Book { get; set; }

        [ForeignKey("TagId")]
        [Required(ErrorMessage = "Tag is required")]
        public Tag Tag { get; set; }
    }
}
