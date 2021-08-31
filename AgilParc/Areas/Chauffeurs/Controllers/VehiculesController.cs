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
    public class VehiculesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiculesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Chauffeurs/Vehicules
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vehicule.Include(v => v.Assurence).Include(v => v.Chauffeur).Include(v => v.Maintenance).Include(v => v.Parc).Include(v => v.Visite);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Chauffeurs/Vehicules/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicule = await _context.Vehicule
                .Include(v => v.Assurence)
                .Include(v => v.Chauffeur)
                .Include(v => v.Maintenance)
                .Include(v => v.Parc)
                .Include(v => v.Visite)
                .FirstOrDefaultAsync(m => m.Matricule == id);
            if (vehicule == null)
            {
                return NotFound();
            }

            return View(vehicule);
        }

        // GET: Chauffeurs/Vehicules/Create
        public IActionResult Create()
        {
            ViewData["AssurenceNumero"] = new SelectList(_context.Assurence, "Numero", "Numero");
            ViewData["ChauffeurId"] = new SelectList(_context.Chauffeur, "Id", "Id");
            ViewData["MaintenanceId"] = new SelectList(_context.Maintenance, "Id", "Id");
            ViewData["ParcNom"] = new SelectList(_context.Parcs, "Nom", "Nom");
            ViewData["VisiteId"] = new SelectList(_context.Visite, "Id", "Id");
            return View();
        }

        // POST: Chauffeurs/Vehicules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricule,Type,NumSerie,DateFabrication,Etat,DateMiseEnCirculation,Kilometrage,Moteur,NbrPortes,MaintenanceId,ParcNom,ChauffeurId,AssurenceNumero,VisiteId")] Vehicule vehicule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssurenceNumero"] = new SelectList(_context.Assurence, "Numero", "Numero", vehicule.AssurenceNumero);
            ViewData["ChauffeurId"] = new SelectList(_context.Chauffeur, "Id", "Id", vehicule.ChauffeurId);
            ViewData["MaintenanceId"] = new SelectList(_context.Maintenance, "Id", "Id", vehicule.MaintenanceId);
            ViewData["ParcNom"] = new SelectList(_context.Parcs, "Nom", "Nom", vehicule.ParcNom);
            ViewData["VisiteId"] = new SelectList(_context.Visite, "Id", "Id", vehicule.VisiteId);
            return View(vehicule);
        }

        // GET: Chauffeurs/Vehicules/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicule = await _context.Vehicule.FindAsync(id);
            if (vehicule == null)
            {
                return NotFound();
            }
            ViewData["AssurenceNumero"] = new SelectList(_context.Assurence, "Numero", "Numero", vehicule.AssurenceNumero);
            ViewData["ChauffeurId"] = new SelectList(_context.Chauffeur, "Id", "Id", vehicule.ChauffeurId);
            ViewData["MaintenanceId"] = new SelectList(_context.Maintenance, "Id", "Id", vehicule.MaintenanceId);
            ViewData["ParcNom"] = new SelectList(_context.Parcs, "Nom", "Nom", vehicule.ParcNom);
            ViewData["VisiteId"] = new SelectList(_context.Visite, "Id", "Id", vehicule.VisiteId);
            return View(vehicule);
        }

        // POST: Chauffeurs/Vehicules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Matricule,Type,NumSerie,DateFabrication,Etat,DateMiseEnCirculation,Kilometrage,Moteur,NbrPortes,MaintenanceId,ParcNom,ChauffeurId,AssurenceNumero,VisiteId")] Vehicule vehicule)
        {
            if (id != vehicule.Matricule)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculeExists(vehicule.Matricule))
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
            ViewData["AssurenceNumero"] = new SelectList(_context.Assurence, "Numero", "Numero", vehicule.AssurenceNumero);
            ViewData["ChauffeurId"] = new SelectList(_context.Chauffeur, "Id", "Id", vehicule.ChauffeurId);
            ViewData["MaintenanceId"] = new SelectList(_context.Maintenance, "Id", "Id", vehicule.MaintenanceId);
            ViewData["ParcNom"] = new SelectList(_context.Parcs, "Nom", "Nom", vehicule.ParcNom);
            ViewData["VisiteId"] = new SelectList(_context.Visite, "Id", "Id", vehicule.VisiteId);
            return View(vehicule);
        }

        // GET: Chauffeurs/Vehicules/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicule = await _context.Vehicule
                .Include(v => v.Assurence)
                .Include(v => v.Chauffeur)
                .Include(v => v.Maintenance)
                .Include(v => v.Parc)
                .Include(v => v.Visite)
                .FirstOrDefaultAsync(m => m.Matricule == id);
            if (vehicule == null)
            {
                return NotFound();
            }

            return View(vehicule);
        }

        // POST: Chauffeurs/Vehicules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vehicule = await _context.Vehicule.FindAsync(id);
            _context.Vehicule.Remove(vehicule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculeExists(string id)
        {
            return _context.Vehicule.Any(e => e.Matricule == id);
        }
    }
}
