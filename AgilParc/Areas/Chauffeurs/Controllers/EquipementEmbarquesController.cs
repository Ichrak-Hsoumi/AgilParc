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
    public class EquipementEmbarquesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipementEmbarquesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Chauffeurs/EquipementEmbarques
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EquipementEmbarque.Include(e => e.Vehicule);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Chauffeurs/EquipementEmbarques/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipementEmbarque = await _context.EquipementEmbarque
                .Include(e => e.Vehicule)
                .FirstOrDefaultAsync(m => m.NumSerie == id);
            if (equipementEmbarque == null)
            {
                return NotFound();
            }

            return View(equipementEmbarque);
        }

        // GET: Chauffeurs/EquipementEmbarques/Create
        public IActionResult Create()
        {
            ViewData["VehiculeId"] = new SelectList(_context.Vehicule, "Matricule", "Matricule");
            return View();
        }

        // POST: Chauffeurs/EquipementEmbarques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumSerie,Nom,DateFabrication,VehiculeId")] EquipementEmbarque equipementEmbarque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipementEmbarque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehiculeId"] = new SelectList(_context.Vehicule, "Matricule", "Matricule", equipementEmbarque.VehiculeId);
            return View(equipementEmbarque);
        }

        // GET: Chauffeurs/EquipementEmbarques/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipementEmbarque = await _context.EquipementEmbarque.FindAsync(id);
            if (equipementEmbarque == null)
            {
                return NotFound();
            }
            ViewData["VehiculeId"] = new SelectList(_context.Vehicule, "Matricule", "Matricule", equipementEmbarque.VehiculeId);
            return View(equipementEmbarque);
        }

        // POST: Chauffeurs/EquipementEmbarques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NumSerie,Nom,DateFabrication,VehiculeId")] EquipementEmbarque equipementEmbarque)
        {
            if (id != equipementEmbarque.NumSerie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipementEmbarque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipementEmbarqueExists(equipementEmbarque.NumSerie))
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
            ViewData["VehiculeId"] = new SelectList(_context.Vehicule, "Matricule", "Matricule", equipementEmbarque.VehiculeId);
            return View(equipementEmbarque);
        }

        // GET: Chauffeurs/EquipementEmbarques/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipementEmbarque = await _context.EquipementEmbarque
                .Include(e => e.Vehicule)
                .FirstOrDefaultAsync(m => m.NumSerie == id);
            if (equipementEmbarque == null)
            {
                return NotFound();
            }

            return View(equipementEmbarque);
        }

        // POST: Chauffeurs/EquipementEmbarques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var equipementEmbarque = await _context.EquipementEmbarque.FindAsync(id);
            _context.EquipementEmbarque.Remove(equipementEmbarque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipementEmbarqueExists(string id)
        {
            return _context.EquipementEmbarque.Any(e => e.NumSerie == id);
        }
    }
}
