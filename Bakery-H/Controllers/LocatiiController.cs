using Bakery_Homework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bakery_H.Services.Interfaces;

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
            var locatii = await _locatiiService.GetAllLocatii();
            return View(locatii);
        }

        // GET: Locatii/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locatii = await _locatiiService.GetLocatieById(id.Value);
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
        public async Task<IActionResult> Create([Bind("IdLocatie,Nume,Adresa,NumarTelefon")] Locatii locatii)
        {
            if (ModelState.IsValid)
            {
                await _locatiiService.CreateLocatie(locatii);
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

            var locatii = await _locatiiService.GetLocatieById(id.Value);
            if (locatii == null)
            {
                return NotFound();
            }
            return View(locatii);
        }

        // POST: Locatii/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLocatie,Nume,Adresa,NumarTelefon")] Locatii locatii)
        {
            if (id != locatii.IdLocatie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _locatiiService.UpdateLocatie(locatii);
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

            var locatii = await _locatiiService.GetLocatieById(id.Value);
            if (locatii == null)
            {
                return NotFound();
            }

            return View(locatii);
        }

        // POST: Locatii/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _locatiiService.DeleteLocatie(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
