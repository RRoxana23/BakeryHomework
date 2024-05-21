using Bakery_Homework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bakery_H.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Bakery_H.Controllers
{
    [Authorize(Roles = "Administrator,Client")]
    public class LocatiiController : Controller
    {
        private readonly ILocatiiService _locatiiService;

        public LocatiiController(ILocatiiService locatiiService)
        {
            _locatiiService = locatiiService;
        }

        // GET: Locatii
        public async Task<IActionResult> Index()
        {
            var locatii = await _locatiiService.GetAllLocatiiAsync();
            return View(locatii);
        }

        // GET: Locatii/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locatii = await _locatiiService.GetLocatieByIdAsync(id.Value);
            if (locatii == null)
            {
                return NotFound();
            }

            return View(locatii);
        }

        // GET: Locatii/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locatii/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("IdLocatie,Nume,Adresa,NumarTelefon,Image")] Locatii locatii)
        {
            if (ModelState.IsValid)
            {
                _locatiiService.CreateLocatieAsync(locatii);
                return RedirectToAction(nameof(Index));
            }
            return View(locatii);
        }

        // GET: Locatii/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locatii = await _locatiiService.GetLocatieByIdAsync(id.Value);
            if (locatii == null)
            {
                return NotFound();
            }
            return View(locatii);
        }

        // POST: Locatii/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLocatie,Nume,Adresa,NumarTelefon,Image")] Locatii locatii)
        {
            if (id != locatii.IdLocatie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Obțineți locația curentă din baza de date
                var existingLocatie = await _locatiiService.GetLocatieByIdAsync(id);
                if (existingLocatie == null)
                {
                    return NotFound();
                }

                // Actualizați doar proprietățile care pot fi modificate
                existingLocatie.Nume = locatii.Nume;
                existingLocatie.Adresa = locatii.Adresa;
                existingLocatie.NumarTelefon = locatii.NumarTelefon;

                // Verificați dacă s-a trimis o imagine nouă; în caz afirmativ, nu o actualizați
                if (locatii.Image != null)
                {
                    existingLocatie.Image = locatii.Image;
                }

                // Actualizați locația în baza de date
                await _locatiiService.UpdateLocatieAsync(existingLocatie);

                return RedirectToAction(nameof(Index));
            }

            return View(locatii);
        }

        // GET: Locatii/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locatii = await _locatiiService.GetLocatieByIdAsync(id.Value);
            if (locatii == null)
            {
                return NotFound();
            }

            return View(locatii);
        }

        // POST: Locatii/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _locatiiService.DeleteLocatie(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
