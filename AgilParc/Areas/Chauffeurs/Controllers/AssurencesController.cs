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
    public class AssurencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssurencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Chauffeurs/Assurences
        public async Task<IActionResult> Index()
        {
            return View(await _context.Assurence.ToListAsync());
        }

        // GET: Chauffeurs/Assurences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assurence = await _context.Assurence
                .FirstOrDefaultAsync(m => m.Numero == id);
            if (assurence == null)
            {
                return NotFound();
            }

            return View(assurence);
        }

        // GET: Chauffeurs/Assurences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chauffeurs/Assurences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Numero,Nom,Date")] Assurence assurence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assurence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assurence);
        }

        // GET: Chauffeurs/Assurences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assurence = await _context.Assurence.FindAsync(id);
            if (assurence == null)
            {
                return NotFound();
            }
            return View(assurence);
        }

        // POST: Chauffeurs/Assurences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Numero,Nom,Date")] Assurence assurence)
        {
            if (id != assurence.Numero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assurence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssurenceExists(assurence.Numero))
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
            return View(assurence);
        }

        // GET: Chauffeurs/Assurences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assurence = await _context.Assurence
                .FirstOrDefaultAsync(m => m.Numero == id);
            if (assurence == null)
            {
                return NotFound();
            }

            return View(assurence);
        }

        // POST: Chauffeurs/Assurences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assurence = await _context.Assurence.FindAsync(id);
            _context.Assurence.Remove(assurence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssurenceExists(int id)
        {
            return _context.Assurence.Any(e => e.Numero == id);
        }
    }
}
