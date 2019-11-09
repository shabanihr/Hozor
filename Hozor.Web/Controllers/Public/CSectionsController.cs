using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hozor.DataLayer.Models;

namespace Hozor.Web.Controllers.Public
{
    public class CSectionsController : Controller
    {
        private readonly Hozor_DBContext _context;

        public CSectionsController(Hozor_DBContext context)
        {
            _context = context;
        }

        // GET: CSections
        public async Task<IActionResult> Index()
        {
            return View(await _context.CSections.ToListAsync());
        }

        // GET: CSections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cSections = await _context.CSections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cSections == null)
            {
                return NotFound();
            }

            return View(cSections);
        }

        // GET: CSections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CSections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CSections cSections)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cSections);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cSections);
        }

        // GET: CSections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cSections = await _context.CSections.FindAsync(id);
            if (cSections == null)
            {
                return NotFound();
            }
            return View(cSections);
        }

        // POST: CSections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CSections cSections)
        {
            if (id != cSections.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cSections);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CSectionsExists(cSections.Id))
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
            return View(cSections);
        }

        // GET: CSections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cSections = await _context.CSections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cSections == null)
            {
                return NotFound();
            }

            return View(cSections);
        }

        // POST: CSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cSections = await _context.CSections.FindAsync(id);
            _context.CSections.Remove(cSections);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CSectionsExists(int id)
        {
            return _context.CSections.Any(e => e.Id == id);
        }
    }
}
