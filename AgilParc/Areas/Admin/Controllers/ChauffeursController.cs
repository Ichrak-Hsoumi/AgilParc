using AgilParc.Data;
using AgilParc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgilParc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChauffeursController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ChauffeursController(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        // GET: ChauffeursController
        public async Task<IActionResult> Index()
        {
            return View(await _db.Chauffeur.ToListAsync());
        }

        // GET: ChauffeursController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var getCh = await _db.Chauffeur.FindAsync(id);
            return View(getCh);
        }

        // GET: ChauffeursController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChauffeursController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Chauffeur chauffeur)
        {
            if (ModelState.IsValid)
            {
                _db.Add(chauffeur);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(chauffeur);
        }

        // GET: ChauffeursController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getDetails = await _db.Chauffeur.FindAsync(id);
            return View(getDetails);
        }

        // POST: ChauffeursController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Chauffeur ch)
        {
            if (ModelState.IsValid)
            {
                _db.Update(ch);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ch);
        }

        // GET: ChauffeursController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var todelete = await _db.Chauffeur.FindAsync(id);
            return View(todelete);
        }

        // POST: ChauffeursController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var todelete = await _db.Chauffeur.FindAsync(id);
            _db.Chauffeur.Remove(todelete);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
