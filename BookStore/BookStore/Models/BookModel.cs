﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BookStore.Enum;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author is required!")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        [Display(Name = "Language")]
        [Required(ErrorMessage = "Language required!")]
        public LanguageEnum LanguageEnum { get; set; }
        [Display(Name = "Total Pages")]
        [Required(ErrorMessage = "Total pages required!")]
        public int? Pages { get; set; }
    }
}
