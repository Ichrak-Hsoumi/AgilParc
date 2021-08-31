using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgilParc.Data;
using AgilParc.Models;

namespace AgilParc.Areas.Chauffeurs.Controllers
{
    [Area("Chauffeurs")]
    public class VisitesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VisitesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Chauffeurs/Visites
        public async Task<IActionResult> Index()
        {
            return View(await _context.Visite.ToListAsync());
        }

        // GET: Chauffeurs/Visites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visite = await _context.Visite
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visite == null)
            {
                return NotFound();
            }

            return View(visite);
        }

        // GET: Chauffeurs/Visites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chauffeurs/Visites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateVisite,DateExpiration")] Visite visite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visite);
        }

        // GET: Chauffeurs/Visites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visite = await _context.Visite.FindAsync(id);
            if (visite == null)
            {
                return NotFound();
            }
            return View(visite);
        }

        // POST: Chauffeurs/Visites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateVisite,DateExpiration")] Visite visite)
        {
            if (id != visite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisiteExists(visite.Id))
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
            return View(visite);
        }

        // GET: Chauffeurs/Visites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visite = await _context.Visite
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visite == null)
            {
                return NotFound();
            }

            return View(visite);
        }

        // POST: Chauffeurs/Visites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visite = await _context.Visite.FindAsync(id);
            _context.Visite.Remove(visite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisiteExists(int id)
        {
            return _context.Visite.Any(e => e.Id == id);
        }
    }
}
