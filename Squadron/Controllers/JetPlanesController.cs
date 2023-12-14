using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        // GET: JetPlanes
        public async Task<IActionResult> Planes()
        {
            return View(await _context.JetPlane.ToListAsync());
        }

        // GET: JetPlanes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jetPlane = await _context.JetPlane
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jetPlane == null)
            {
                return NotFound();
            }

            return View(jetPlane);
        }

        // GET: JetPlanes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JetPlanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Condition,Year,Price")] JetPlane jetPlane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jetPlane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jetPlane);
        }

        // GET: JetPlanes/Edit/5
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Condition,Year,Price")] JetPlane jetPlane)
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
                return RedirectToAction(nameof(Index));
            }
            return View(jetPlane);
        }

        // GET: JetPlanes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jetPlane = await _context.JetPlane
                .FirstOrDefaultAsync(m => m.Id == id);
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
            return RedirectToAction(nameof(Index));
        }

        private bool JetPlaneExists(int id)
        {
            return _context.JetPlane.Any(e => e.Id == id);
        }
    }
}
