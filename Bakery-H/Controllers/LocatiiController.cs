using Bakery_Homework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bakery_H.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Bakery_H.Controllers
{
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
        [Authorize(Policy = "RequireAdministratorRole")]
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
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> Edit(int id, [Bind("IdLocatie,Nume,Adresa,NumarTelefon,Image")] Locatii locatii)
        {
            if (id != locatii.IdLocatie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingLocatie = await _locatiiService.GetLocatieByIdAsync(id);
                if (existingLocatie == null)
                {
                    return NotFound();
                }

                existingLocatie.Nume = locatii.Nume;
                existingLocatie.Adresa = locatii.Adresa;
                existingLocatie.NumarTelefon = locatii.NumarTelefon;

                if (locatii.Image != null)
                {
                    existingLocatie.Image = locatii.Image;
                }

                await _locatiiService.UpdateLocatieAsync(existingLocatie);

                return RedirectToAction(nameof(Index));
            }

            return View(locatii);
        }

        // GET: Locatii/Delete/5
        [Authorize(Policy = "RequireAdministratorRole")]
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
        [Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult DeleteConfirmed(int id)
        {
            _locatiiService.DeleteLocatie(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
