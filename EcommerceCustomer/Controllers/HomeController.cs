using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EcommerceCustomer.Models;
using EcommerceCustomer.Data;
using Microsoft.EntityFrameworkCore;

namespace EcommerceCustomer.Controllers
{
    public class HomeController : Controller
    {
        private readonly EcommerceDbContext _context;

        public HomeController(EcommerceDbContext context)
        {
            _context = context;
        }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            var products = _context.Products.Include(p => p.Category).ToList();

            // Pass data to the view
            ViewBag.Categories = categories;
            ViewBag.Products = products;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
