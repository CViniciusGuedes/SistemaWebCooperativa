using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaWebCooperativa.Models;

namespace SistemaWebCooperativa.Controllers
{
    public class TipoInsumoesController : Controller
    {
        private readonly Contexto _context;

        public TipoInsumoesController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoInsumoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.TipoInsumo.ToListAsync());
        }

        // GET: TipoInsumoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoInsumo == null)
            {
                return NotFound();
            }

            var tipoInsumo = await _context.TipoInsumo
                .FirstOrDefaultAsync(m => m.id == id);
            if (tipoInsumo == null)
            {
                return NotFound();
            }

            return View(tipoInsumo);
        }

        // GET: TipoInsumoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoInsumoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao")] TipoInsumo tipoInsumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoInsumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoInsumo);
        }

        // GET: TipoInsumoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoInsumo == null)
            {
                return NotFound();
            }

            var tipoInsumo = await _context.TipoInsumo.FindAsync(id);
            if (tipoInsumo == null)
            {
                return NotFound();
            }
            return View(tipoInsumo);
        }

        // POST: TipoInsumoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao")] TipoInsumo tipoInsumo)
        {
            if (id != tipoInsumo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoInsumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoInsumoExists(tipoInsumo.id))
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
            return View(tipoInsumo);
        }

        // GET: TipoInsumoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoInsumo == null)
            {
                return NotFound();
            }

            var tipoInsumo = await _context.TipoInsumo
                .FirstOrDefaultAsync(m => m.id == id);
            if (tipoInsumo == null)
            {
                return NotFound();
            }

            return View(tipoInsumo);
        }

        // POST: TipoInsumoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoInsumo == null)
            {
                return Problem("Entity set 'Contexto.TipoInsumo'  is null.");
            }
            var tipoInsumo = await _context.TipoInsumo.FindAsync(id);
            if (tipoInsumo != null)
            {
                _context.TipoInsumo.Remove(tipoInsumo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoInsumoExists(int id)
        {
          return _context.TipoInsumo.Any(e => e.id == id);
        }
    }
}
