using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        [ViewData]
        public string Title { get; set; }

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [Route("allbooks")]
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            Title = "All Books";
            return View(data);
        }
        [Route("book")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            Title = data.Title;
            return View(data);
        }
        //[Route("new")]
        public ViewResult AddNewBook(bool isSuccess = false) 
        {
            Title = "Add Book";
            ViewBag.isSuccess = isSuccess;
            ViewBag.Language = GetLanguage().Select(x => new SelectListItem()
            { 
                Text = x.Text,
                Value = x.Id.ToString()
            }).ToList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            Title = "Add Book";
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0) return RedirectToAction("AddNewBook", new { isSuccess = true });
            }
            return View();
        }

        private List<LanguageModel> GetLanguage() 
        {
            return new List<LanguageModel>()
            {
                new LanguageModel() { Id = 1, Text = "English"},
                new LanguageModel() { Id = 2, Text = "Korean"},
                new LanguageModel() { Id = 3, Text = "Tagalog"},
                new LanguageModel() { Id = 4, Text = "Chinese"},
                new LanguageModel() { Id = 5, Text = "Japanese"}
            };
        }
    }
}
