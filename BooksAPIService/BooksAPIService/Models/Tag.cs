﻿using System.ComponentModel.DataAnnotations;

namespace BooksAPIService.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tag Name is Required")]
        [MinLength(2)]
        public string Name { get; set; }

    }
}