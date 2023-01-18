using Microsoft.AspNetCore.Mvc;
using Pronia_Task_.DAL;
using System;

namespace Pronia_Task_.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Shop()
        {
            return View();
        }
    }
}
