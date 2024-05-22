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
    public class FormulareAngajareController : Controller
    {
        private readonly BakeryDbContext _context;

        public FormulareAngajareController(BakeryDbContext context)
        {
            _context = context;
        }

        // GET: FormulareAngajare
        public async Task<IActionResult> Index()
        {
            var bakeryDbContext = _context.FormulareAngajare.Include(f => f.Locatie);
            return View(await bakeryDbContext.ToListAsync());
        }

        // GET: FormulareAngajare/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulareAngajare = await _context.FormulareAngajare
                .Include(f => f.Locatie)
                .FirstOrDefaultAsync(m => m.IdFormular == id);
            if (formulareAngajare == null)
            {
                return NotFound();
            }

            return View(formulareAngajare);
        }

        // GET: FormulareAngajare/Create
        public IActionResult Create()
        {
            var locatii = _context.Locatii
            .Select(l => new SelectListItem
            {
                Value = l.IdLocatie.ToString(),
                Text = l.Nume
            })
            .ToList();

            ViewData["LocatieId"] = locatii;
            return View();
        }

        // POST: FormulareAngajare/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFormular,Nume,Prenume,DataNasterii,NumarTelefon,Email,LocatieId")] FormulareAngajare formulareAngajare)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(formulareAngajare);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Formularul a fost trimis cu succes!";
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "A apărut o eroare la salvarea datelor pe server.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Eroare la validarea datelor formularului.";
            }

            // Reîncarcă view-ul Create, menținând mesajele de succes sau eroare
            var locatii = _context.Locatii
                .Select(l => new SelectListItem
                {
                    Value = l.IdLocatie.ToString(),
                    Text = l.Nume
                })
                .ToList();

            ViewData["LocatieId"] = locatii;
            return View(formulareAngajare);
        }


        // GET: FormulareAngajare/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulareAngajare = await _context.FormulareAngajare.FindAsync(id);
            if (formulareAngajare == null)
            {
                return NotFound();
            }
            ViewData["LocatieId"] = new SelectList(_context.Locatii, "IdLocatie", "IdLocatie", formulareAngajare.LocatieId);
            return View(formulareAngajare);
        }

        // POST: FormulareAngajare/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFormular,Nume,Prenume,DataNasterii,NumarTelefon,Email,LocatieId")] FormulareAngajare formulareAngajare)
        {
            if (id != formulareAngajare.IdFormular)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formulareAngajare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormulareAngajareExists(formulareAngajare.IdFormular))
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
            ViewData["LocatieId"] = new SelectList(_context.Locatii, "IdLocatie", "IdLocatie", formulareAngajare.LocatieId);
            return View(formulareAngajare);
        }

        // GET: FormulareAngajare/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulareAngajare = await _context.FormulareAngajare
                .Include(f => f.Locatie)
                .FirstOrDefaultAsync(m => m.IdFormular == id);
            if (formulareAngajare == null)
            {
                return NotFound();
            }

            return View(formulareAngajare);
        }

        // POST: FormulareAngajare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formulareAngajare = await _context.FormulareAngajare.FindAsync(id);
            if (formulareAngajare != null)
            {
                _context.FormulareAngajare.Remove(formulareAngajare);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormulareAngajareExists(int id)
        {
            return _context.FormulareAngajare.Any(e => e.IdFormular == id);
        }
    }
}