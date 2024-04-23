using Microsoft.AspNetCore.Mvc;
using Squadron.Data;
using Squadron.Models;
using System.Diagnostics;

namespace Squadron.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowSearchForm()
        {
            return View();
        }

        public IActionResult ShowSearchResults(string searchPhrase)
        {
            var items = _context.JetPlane.Where(p => p.Model.Contains(searchPhrase)).ToList();

            ViewBag.SearchPhrase = searchPhrase;

            return View(items);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}