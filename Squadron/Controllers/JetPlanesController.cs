using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Squadron.Data;
using Squadron.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Squadron.Controllers
{
    public class JetPlanesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JetPlanesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JetPlanes/Planes
        public IActionResult Planes()
        {
            // Redirect to the default category (e.g., Fighters)
            return RedirectToAction(nameof(Fighters));
        }

        // GET: JetPlanes/Fighters
        public async Task<IActionResult> Fighters()
        {
            var fighterPlanes = await _context.JetPlane.Where(p => p.Category == "Fighter").ToListAsync();
            return View("JetPlaneList", fighterPlanes);
        }

        // GET: JetPlanes/Attackers
        public async Task<IActionResult> Attackers()
        {
            var attackerPlanes = await _context.JetPlane.Where(p => p.Category == "Attacker").ToListAsync();
            return View("JetPlaneList", attackerPlanes);
        }

        // GET: JetPlanes/Bombers
        public async Task<IActionResult> Bombers()
        {
            var bomberPlanes = await _context.JetPlane.Where(p => p.Category == "Bomber").ToListAsync();
            return View("JetPlaneList", bomberPlanes);
        }

        // GET: JetPlanes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JetPlanes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Model,Category,Year,Price")] JetPlane jetPlane)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(jetPlane);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Planes)); // Redirect to the list of planes or your desired action
                }
            }
            catch (DbUpdateException)
            {
                // Log the error or handle it as needed
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View(jetPlane);
        }

        private bool JetPlaneExists(int id)
        {
            return _context.JetPlane.Any(e => e.Id == id);
        }
    }
}


