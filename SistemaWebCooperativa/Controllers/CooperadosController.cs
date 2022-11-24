using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaWebCooperativa.Models;

namespace SistemaWebCooperativa.Controllers
{
    [Authorize]
    public class CooperadosController : Controller
    {
        private readonly Contexto _context;

        public CooperadosController(Contexto context)
        {
            _context = context;
        }

        // GET: Cooperados
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Cooperado.Include(c => c.propriedade);
            return View(await contexto.ToListAsync());
        }

        // GET: Cooperados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cooperado == null)
            {
                return NotFound();
            }

            var cooperado = await _context.Cooperado
                .Include(c => c.propriedade)
                .FirstOrDefaultAsync(m => m.id == id);
            if (cooperado == null)
            {
                return NotFound();
            }

            return View(cooperado);
        }

        // GET: Cooperados/Create
        public IActionResult Create()
        {
            ViewData["propriedadeid"] = new SelectList(_context.Propriedade, "Id", "nome");
            return View();
        }

        // POST: Cooperados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,telefone,email,cpf,propriedadeid")] Cooperado cooperado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cooperado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["propriedadeid"] = new SelectList(_context.Propriedade, "Id", "nome", cooperado.propriedadeid);
            return View(cooperado);
        }

        // GET: Cooperados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cooperado == null)
            {
                return NotFound();
            }

            var cooperado = await _context.Cooperado.FindAsync(id);
            if (cooperado == null)
            {
                return NotFound();
            }
            ViewData["propriedadeid"] = new SelectList(_context.Propriedade, "Id", "nome", cooperado.propriedadeid);
            return View(cooperado);
        }

        // POST: Cooperados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,telefone,email,cpf,propriedadeid")] Cooperado cooperado)
        {
            if (id != cooperado.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cooperado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CooperadoExists(cooperado.id))
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
            ViewData["propriedadeid"] = new SelectList(_context.Propriedade, "Id", "nome", cooperado.propriedadeid);
            return View(cooperado);
        }

        // GET: Cooperados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cooperado == null)
            {
                return NotFound();
            }

            var cooperado = await _context.Cooperado
                .Include(c => c.propriedade)
                .FirstOrDefaultAsync(m => m.id == id);
            if (cooperado == null)
            {
                return NotFound();
            }

            return View(cooperado);
        }

        // POST: Cooperados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cooperado == null)
            {
                return Problem("Entity set 'Contexto.Cooperado'  is null.");
            }
            var cooperado = await _context.Cooperado.FindAsync(id);
            if (cooperado != null)
            {
                _context.Cooperado.Remove(cooperado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CooperadoExists(int id)
        {
          return _context.Cooperado.Any(e => e.id == id);
        }
    }
}
