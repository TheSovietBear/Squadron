using Microsoft.AspNetCore.Mvc;
using Squadron.Models;
using System.Diagnostics;

namespace Squadron.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
    public async IActionResult Index()
        {
            return View(await _context.Jet
        }
    public IActionResult ShowSearchForm()
        {
            return View();
        }
        public IActionResult ShowSearchResults(string SearchPhrase)
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

