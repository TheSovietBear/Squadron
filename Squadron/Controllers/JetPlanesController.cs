using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Squadron.Data;
using Squadron.Models;

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
            var fighterPlanes = await _context.JetPlane.Where(p => p.Category == JetPlaneType.Fighter).ToListAsync();
            return View("JetPlaneList", fighterPlanes);
        }

        // GET: JetPlanes/Attackers
        public async Task<IActionResult> Attackers()
        {
            var attackerPlanes = await _context.JetPlane.Where(p => p.Category == JetPlaneType.Attacker).ToListAsync();
            return View("JetPlaneList", attackerPlanes);
        }

        // GET: JetPlanes/Bombers
        public async Task<IActionResult> Bombers()
        {
            var bomberPlanes = await _context.JetPlane.Where(p => p.Category == JetPlaneType.Bomber).ToListAsync();
            return View("JetPlaneList", bomberPlanes);
        }

        // GET: JetPlanes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JetPlanes/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Model,Category,Condition,Year,Price")] JetPlane jetPlane)
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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jetPlane = await _context.JetPlane.FindAsync(id);

            if (jetPlane == null)
            {
                return NotFound();
            }
            return View(jetPlane);
        }

        // POST: JetPlanes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Condition,Year,Price,Category")] JetPlane jetPlane)
        {
            if (id != jetPlane.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jetPlane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JetPlaneExists(jetPlane.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Fighters));
            }
            return View(jetPlane);
        }

        private bool JetPlaneExists(int id)
        {
            return _context.JetPlane.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jetPlane = await _context.JetPlane.FirstOrDefaultAsync(m => m.Id == id);

            if (jetPlane == null)
            {
                return NotFound();
            }

            return View(jetPlane);
        }

        // POST: JetPlanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jetPlane = await _context.JetPlane.FindAsync(id);

            if (jetPlane != null)
            {
                _context.JetPlane.Remove(jetPlane);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Fighters));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jetPlane = await _context.JetPlane.FirstOrDefaultAsync(m => m.Id == id);

            if (jetPlane == null)
            {
                return NotFound();
            }

            return View(jetPlane);
        }
    }
}


