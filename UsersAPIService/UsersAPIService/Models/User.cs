using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UsersAPIService.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MinLength(3, ErrorMessage = "Name must be length of 3")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Must be valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(4, ErrorMessage = "Password must be atleast of length 4")]
        public string Password { get; set; }

        [DefaultValue("Visitor")]
        public string Role { get; set; } 
    }
}
