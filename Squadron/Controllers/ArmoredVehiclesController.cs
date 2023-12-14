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
    public class ArmoredVehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArmoredVehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArmoredVehicles
        public async Task<IActionResult> Tanks()
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

            var armoredVehicle = await _context.ArmoredVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Condition,Year,Price")] ArmoredVehicle armoredVehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(armoredVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Condition,Year,Price")] ArmoredVehicle armoredVehicle)
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
                return RedirectToAction(nameof(Index));
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

            var armoredVehicle = await _context.ArmoredVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
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
            return RedirectToAction(nameof(Index));
        }

        private bool ArmoredVehicleExists(int id)
        {
            return _context.ArmoredVehicle.Any(e => e.Id == id);
        }
    }
}
