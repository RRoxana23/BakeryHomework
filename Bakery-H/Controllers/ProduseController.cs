using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bakery_Homework.Models;

namespace Bakery_H.Controllers
{
    public class ProduseController : Controller
    {
        private readonly BakeryDbContext _context;

        public ProduseController(BakeryDbContext context)
        {
            _context = context;
        }

        // GET: Produse
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produse.ToListAsync());
        }

        // GET: Produse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produse = await _context.Produse
                .FirstOrDefaultAsync(m => m.IdProdus == id);
            if (produse == null)
            {
                return NotFound();
            }

            return View(produse);
        }

        // GET: Produse/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProdus,Nume,Descriere,Ingrediente,Pret,Cantitate,Image")] Produse produse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produse);
        }

        // GET: Produse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produse = await _context.Produse.FindAsync(id);
            if (produse == null)
            {
                return NotFound();
            }
            return View(produse);
        }

        // POST: Produse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProdus,Nume,Descriere,Ingrediente,Pret,Cantitate,Image")] Produse produse)
        {
            if (id != produse.IdProdus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduseExists(produse.IdProdus))
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
            return View(produse);
        }

        // GET: Produse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produse = await _context.Produse
                .FirstOrDefaultAsync(m => m.IdProdus == id);
            if (produse == null)
            {
                return NotFound();
            }

            return View(produse);
        }

        // POST: Produse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produse = await _context.Produse.FindAsync(id);
            if (produse != null)
            {
                _context.Produse.Remove(produse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduseExists(int id)
        {
            return _context.Produse.Any(e => e.IdProdus == id);
        }
    }
}
