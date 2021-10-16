using System.Diagnostics;
using cuima.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using cuima.Models;

namespace cuima.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ImageContext _context;

        public HomeController(ILogger<HomeController> logger, ImageContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostImage(string name)
        {
            var image = new Image
            {
                Id = ImageContext.GenerateImageId(),
                Name = name,
            };
            
            _context.Add(image);
            _context.SaveChanges();
            
            _logger.LogInformation($"Post image {image.Id} named {image.Name} at {image.Path}");

            return View("Image", image);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}