using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AmigoOculto.DbContext;
using AmigoOculto.Models.User;

namespace AmigoOculto.Controllers
{
    public class SugestoesPresentesController : Controller
    {
        private readonly AppDbContext _context;

        public SugestoesPresentesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SugestoesPresentes
        public async Task<IActionResult> Index()
        {
              return View(await _context.SugestoesPresente.ToListAsync());
        }

        // GET: SugestoesPresentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SugestoesPresente == null)
            {
                return NotFound();
            }

            var sugestoesPresente = await _context.SugestoesPresente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sugestoesPresente == null)
            {
                return NotFound();
            }

            return View(sugestoesPresente);
        }

        // GET: SugestoesPresentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SugestoesPresentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Descricao,Codigo")] SugestoesPresente sugestoesPresente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sugestoesPresente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sugestoesPresente);
        }

        // GET: SugestoesPresentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SugestoesPresente == null)
            {
                return NotFound();
            }

            var sugestoesPresente = await _context.SugestoesPresente.FindAsync(id);
            if (sugestoesPresente == null)
            {
                return NotFound();
            }
            return View(sugestoesPresente);
        }

        // POST: SugestoesPresentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Descricao,Codigo")] SugestoesPresente sugestoesPresente)
        {
            if (id != sugestoesPresente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sugestoesPresente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SugestoesPresenteExists(sugestoesPresente.Id))
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
            return View(sugestoesPresente);
        }

        // GET: SugestoesPresentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SugestoesPresente == null)
            {
                return NotFound();
            }

            var sugestoesPresente = await _context.SugestoesPresente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sugestoesPresente == null)
            {
                return NotFound();
            }

            return View(sugestoesPresente);
        }

        // POST: SugestoesPresentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SugestoesPresente == null)
            {
                return Problem("Entity set 'AppDbContext.SugestoesPresente'  is null.");
            }
            var sugestoesPresente = await _context.SugestoesPresente.FindAsync(id);
            if (sugestoesPresente != null)
            {
                _context.SugestoesPresente.Remove(sugestoesPresente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SugestoesPresenteExists(int id)
        {
          return _context.SugestoesPresente.Any(e => e.Id == id);
        }
    }
}
