using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }
        public ViewResult Index() {
            Title = "Home";
            return View();
        }
        [Route("about")]
        public ViewResult AboutUs()
        {
            Title = "About";
            return View();
        }
        [Route("contact")]
        public ViewResult ContactUs()
        {
            Title = "Contact";
            return View();
        }
    }
}
