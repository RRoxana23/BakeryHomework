using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bakery_Homework.Models;
using Bakery_H.Services.Interfaces;

namespace Bakery_H.Controllers
{
    public class FormulareAngajareController : Controller
    {
        private readonly IFormulareAngajareService _formulareAngajareService;
        private readonly ILocatiiService _locatiiService;

        public FormulareAngajareController(IFormulareAngajareService formulareAngajareService, ILocatiiService locatiiService)
        {
            _formulareAngajareService = formulareAngajareService;
            _locatiiService = locatiiService;
        }

        // GET: FormulareAngajare
        public async Task<IActionResult> Index()
        {
            var formulareAngajare = await _formulareAngajareService.GetAllFormulareAsync();
            return View(formulareAngajare);
        }

        // GET: FormulareAngajare/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulareAngajare = await _formulareAngajareService.GetFormularByIdAsync(id.Value);
            if (formulareAngajare == null)
            {
                return NotFound();
            }

            return View(formulareAngajare);
        }

        // GET: FormulareAngajare/Create
        public async Task<IActionResult> Create()
        {
            var locatii = await _locatiiService.GetAllLocatiiAsync();
            ViewData["LocatieId"] = locatii.Select(l => new SelectListItem
            {
                Value = l.IdLocatie.ToString(),
                Text = l.Nume
            }).ToList();
            return View();
        }

        // POST: FormulareAngajare/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFormular,Nume,Prenume,DataNasterii,NumarTelefon,Email,LocatieId")] FormulareAngajare formulareAngajare)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _formulareAngajareService.CreateFormularAsync(formulareAngajare);
                    TempData["SuccessMessage"] = "Formularul a fost trimis cu succes!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    TempData["ErrorMessage"] = "A apărut o eroare la salvarea datelor pe server.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Eroare la validarea datelor formularului.";
            }

            // Reîncarcă view-ul Create, menținând mesajele de succes sau eroare
            var locatii = await _locatiiService.GetAllLocatiiAsync();
            ViewData["LocatieId"] = locatii.Select(l => new SelectListItem
            {
                Value = l.IdLocatie.ToString(),
                Text = l.Nume
            }).ToList();
            return View(formulareAngajare);
        }

        // GET: FormulareAngajare/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulareAngajare = await _formulareAngajareService.GetFormularByIdAsync(id.Value);
            if (formulareAngajare == null)
            {
                return NotFound();
            }

            var locatii = await _locatiiService.GetAllLocatiiAsync();
            ViewData["LocatieId"] = new SelectList(locatii, "IdLocatie", "Nume", formulareAngajare.LocatieId);
            return View(formulareAngajare);
        }

        // POST: FormulareAngajare/Edit/5
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
                    await _formulareAngajareService.UpdateFormularAsync(formulareAngajare);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await FormulareAngajareExists(formulareAngajare.IdFormular))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            var locatii = await _locatiiService.GetAllLocatiiAsync();
            ViewData["LocatieId"] = new SelectList(locatii, "IdLocatie", "Nume", formulareAngajare.LocatieId);
            return View(formulareAngajare);
        }

        // GET: FormulareAngajare/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulareAngajare = await _formulareAngajareService.GetFormularByIdAsync(id.Value);
            if (formulareAngajare == null)
            {
                return NotFound();
            }

            return View(formulareAngajare);
        }

        // POST: FormulareAngajare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _formulareAngajareService.DeleteFormular(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FormulareAngajareExists(int id)
        {
            var formulare = await _formulareAngajareService.GetFormularByIdAsync(id);
            return formulare != null;
        }
    }
}
