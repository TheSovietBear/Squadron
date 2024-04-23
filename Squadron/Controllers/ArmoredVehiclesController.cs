using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Squadron.Data;
using Squadron.Models;

namespace Squadron.Controllers
{
    public class ArmoredVehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArmoredVehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArmoredVehicles/Tanks
        public async Task<IActionResult> Tanks()
        {
            var items = await _context.ArmoredVehicle.Where(v => v.Category == ArmoredVehicleType.Tank).ToListAsync();

            return View("ArmoredVehicleList", items);
        }

        // GET: ArmoredVehicles/APCs
        public async Task<IActionResult> APCs()
        {
            var items = await _context.ArmoredVehicle.Where(v => v.Category == ArmoredVehicleType.APC).ToListAsync();

            return View("ArmoredVehicleList", items);
        }

        // GET: ArmoredVehicles/IFVs
        public async Task<IActionResult> IFVs()
        {
            var items = await _context.ArmoredVehicle.Where(v => v.Category == ArmoredVehicleType.IFV).ToListAsync();

            return View("ArmoredVehicleList", items);
        }

        // GET: ArmoredVehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArmoredVehicle.ToListAsync());
        }

        // GET: ArmoredVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armoredVehicle = await _context.ArmoredVehicle.FirstOrDefaultAsync(m => m.Id == id);
            if (armoredVehicle == null)
            {
                return NotFound();
            }

            return View(armoredVehicle);
        }

        // GET: ArmoredVehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArmoredVehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Condition,Year,Price,Category,Description,PictureUrl")] ArmoredVehicle armoredVehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(armoredVehicle);
                await _context.SaveChangesAsync();
                // Redirect to the ArmoredVehicleList action after successfully creating the item
                return RedirectToAction(nameof(ArmoredVehicleList));
            }
            return View(armoredVehicle);
        }


        // GET: ArmoredVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armoredVehicle = await _context.ArmoredVehicle.FindAsync(id);
            if (armoredVehicle == null)
            {
                return NotFound();
            }
            return View(armoredVehicle);
        }

        // POST: ArmoredVehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Condition,Year,Price,Category,Picture,Description")] ArmoredVehicle armoredVehicle)
        {
            if (id != armoredVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(armoredVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmoredVehicleExists(armoredVehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Tanks));
            }
            return View(armoredVehicle);
        }

        // GET: ArmoredVehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armoredVehicle = await _context.ArmoredVehicle.FirstOrDefaultAsync(m => m.Id == id);
            if (armoredVehicle == null)
            {
                return NotFound();
            }

            return View(armoredVehicle);
        }

        // POST: ArmoredVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var armoredVehicle = await _context.ArmoredVehicle.FindAsync(id);
            if (armoredVehicle != null)
            {
                _context.ArmoredVehicle.Remove(armoredVehicle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Tanks));
        }

        private bool ArmoredVehicleExists(int id)
        {
            return _context.ArmoredVehicle.Any(e => e.Id == id);
        }

        // GET: ArmoredVehicles/ArmoredVehicleList
        public async Task<IActionResult> ArmoredVehicleList()
        {
            return View(await _context.ArmoredVehicle.ToListAsync());
        }
    }
}