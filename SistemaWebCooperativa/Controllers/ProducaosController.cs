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
    public class ProducaosController : Controller
    {
        private readonly Contexto _context;

        public ProducaosController(Contexto context)
        {
            _context = context;
        }

        // GET: Producaos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Producao.ToListAsync());
        }

        // GET: Producaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Producao == null)
            {
                return NotFound();
            }

            var producao = await _context.Producao
                .FirstOrDefaultAsync(m => m.id == id);
            if (producao == null)
            {
                return NotFound();
            }

            return View(producao);
        }

        // GET: Producaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,descricao,preco")] Producao producao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producao);
        }

        // GET: Producaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Producao == null)
            {
                return NotFound();
            }

            var producao = await _context.Producao.FindAsync(id);
            if (producao == null)
            {
                return NotFound();
            }
            return View(producao);
        }

        // POST: Producaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,descricao,preco")] Producao producao)
        {
            if (id != producao.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducaoExists(producao.id))
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
            return View(producao);
        }

        // GET: Producaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Producao == null)
            {
                return NotFound();
            }

            var producao = await _context.Producao
                .FirstOrDefaultAsync(m => m.id == id);
            if (producao == null)
            {
                return NotFound();
            }

            return View(producao);
        }

        // POST: Producaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Producao == null)
            {
                return Problem("Entity set 'Contexto.Producao'  is null.");
            }
            var producao = await _context.Producao.FindAsync(id);
            if (producao != null)
            {
                _context.Producao.Remove(producao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducaoExists(int id)
        {
          return _context.Producao.Any(e => e.id == id);
        }
    }
}
