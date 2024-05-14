using Bakery_H.Services.Interfaces;
using Bakery_Homework.Models;
using Bakery_Homework.Repositories.Interfaces;
using Bakery_Homework.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery_H.Controllers
{
    [Authorize(Policy = "RequireAdministratorRole")]
    public class AngajatiController : Controller
    {
        private readonly IAngajatiService _angajatiService;

        public AngajatiController(IAngajatiService angajatiService)
        {
            _angajatiService = angajatiService;
        }

        // GET: Angajati
        public async Task<IActionResult> Index()
        {
            var angajati = await _angajatiService.GetAllAsync();
            return View(angajati);
        }

        // GET: Angajati/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angajati = await _angajatiService.GetByIdAsync(id.Value);
            if (angajati == null)
            {
                return NotFound();
            }

            return View(angajati);
        }

        // GET: Angajati/Create
        public IActionResult Create()
        {
            ViewData["FormulareAngajareId"] = new SelectList(_angajatiService.GetAllFormulareAngajare(), "IdFormular", "IdFormular");
            ViewData["LocatieId"] = new SelectList(_angajatiService.GetAllLocatii(), "IdLocatie", "IdLocatie");
            ViewData["userId"] = new SelectList(_angajatiService.GetAllUsers(), "Id", "Id");
            return View();
        }

        // POST: Angajati/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Angajati angajati)
        {
            if (ModelState.IsValid)
            {
                await _angajatiService.CreateAsync(angajati);
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormulareAngajareId"] = new SelectList(_angajatiService.GetAllFormulareAngajare(), "IdFormular", "IdFormular", angajati.FormulareAngajareId);
            ViewData["LocatieId"] = new SelectList(_angajatiService.GetAllLocatii(), "IdLocatie", "IdLocatie", angajati.LocatieId);
            ViewData["userId"] = new SelectList(_angajatiService.GetAllUsers(), "Id", "Id", angajati.userId);
            return View(angajati);
        }

        // GET: Angajati/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angajati = await _angajatiService.GetByIdAsync(id.Value);
            if (angajati == null)
            {
                return NotFound();
            }
            ViewData["FormulareAngajareId"] = new SelectList(_angajatiService.GetAllFormulareAngajare(), "IdFormular", "IdFormular", angajati.FormulareAngajareId);
            ViewData["LocatieId"] = new SelectList(_angajatiService.GetAllLocatii(), "IdLocatie", "IdLocatie", angajati.LocatieId);
            ViewData["userId"] = new SelectList(_angajatiService.GetAllUsers(), "Id", "Id", angajati.userId);
            return View(angajati);
        }

        // POST: Angajati/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Angajati angajati)
        {
            if (id != angajati.IdAngajat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _angajatiService.UpdateAsync(angajati);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_angajatiService.AngajatiExists(angajati.IdAngajat))
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
            ViewData["FormulareAngajareId"] = new SelectList(_angajatiService.GetAllFormulareAngajare(), "IdFormular", "IdFormular", angajati.FormulareAngajareId);
            ViewData["LocatieId"] = new SelectList(_angajatiService.GetAllLocatii(), "IdLocatie", "IdLocatie", angajati.LocatieId);
            ViewData["userId"] = new SelectList(_angajatiService.GetAllUsers(), "Id", "Id", angajati.userId);
            return View(angajati);
        }

        // GET: Angajati/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angajati = await _angajatiService.GetByIdAsync(id.Value);
            if (angajati == null)
            {
                return NotFound();
            }

            return View(angajati);
        }

        // POST: Angajati/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _angajatiService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
