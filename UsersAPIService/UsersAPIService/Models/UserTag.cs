using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersAPIService.Models
{
    public class UserTag
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        [Required(ErrorMessage = "User is required")]
        public User User { get; set; }

        [ForeignKey("TagId")]
        [Required(ErrorMessage = "Tag is required")]
        public Tag Tag { get; set; } 
    }
}
