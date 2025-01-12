using Bakery_Homework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bakery_H.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Bakery_H.Controllers
{
    public class ProduseController : Controller
    {
        private readonly IProduseService _produseService;

        public ProduseController(IProduseService produseService)
        {
            _produseService = produseService;
        }

        // GET: Produse
        public async Task<IActionResult> Index()
        {
            var produse = await _produseService.GetAllProduseAsync();
            return View(produse);
        }

        // GET: Produse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produse = await _produseService.GetProdusByIdAsync(id.Value);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProdus,Nume,Descriere,Ingrediente,Pret,Cantitate,Image")] Produse produse)
        {
            if (ModelState.IsValid)
            {
                await _produseService.CreateProdusAsync(produse);
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

            var produse = await _produseService.GetProdusByIdAsync(id.Value);
            if (produse == null)
            {
                return NotFound();
            }
            return View(produse);
        }

        // POST: Produse/Edit/5
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
                    await _produseService.UpdateProdusAsync(produse);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProduseExists(produse.IdProdus))
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

            var produse = await _produseService.GetProdusByIdAsync(id.Value);
            if (produse == null)
            {
                return NotFound();
            }

            return View(produse);
        }

        // POST: Produse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _produseService.DeleteProdus(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProduseExists(int id)
        {
            var produse = await _produseService.GetProdusByIdAsync(id);
            return produse != null;
        }
    }
}
