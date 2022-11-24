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
    public class ProducoesController : Controller
    {
        private readonly Contexto _context;

        public ProducoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Producoes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Producao.Include(p => p.cooperado).Include(p => p.produto);
            return View(await contexto.ToListAsync());
        }

        // GET: Producoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Producao == null)
            {
                return NotFound();
            }

            var producao = await _context.Producao
                .Include(p => p.cooperado)
                .Include(p => p.produto)
                .FirstOrDefaultAsync(m => m.id == id);
            if (producao == null)
            {
                return NotFound();
            }

            return View(producao);
        }

        // GET: Producoes/Create
        public IActionResult Create()
        {
            ViewData["cooperadoid"] = new SelectList(_context.Cooperado, "id", "nome");
            ViewData["produtoid"] = new SelectList(_context.Produto, "id", "nome");
            return View();
        }

        // POST: Producoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,cooperadoid,produtoid,quantidade")] Producao producao)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(producao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["cooperadoid"] = new SelectList(_context.Cooperado, "id", "nome", producao.cooperadoid);
            ViewData["produtoid"] = new SelectList(_context.Produto, "id", "nome", producao.produtoid);
            return View(producao);
        }

        // GET: Producoes/Edit/5
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
            ViewData["cooperadoid"] = new SelectList(_context.Cooperado, "id", "nome", producao.cooperadoid);
            ViewData["produtoid"] = new SelectList(_context.Produto, "id", "nome", producao.produtoid);
            return View(producao);
        }

        // POST: Producoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,cooperadoid,produtoid,quantidade")] Producao producao)
        {
            if (id != producao.id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
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
            //}
            ViewData["cooperadoid"] = new SelectList(_context.Cooperado, "id", "nome", producao.cooperado);
            ViewData["produtoid"] = new SelectList(_context.Produto, "id", "nome", producao.produto);
            return View(producao);
        }

        // GET: Producoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Producao == null)
            {
                return NotFound();
            }

            var producao = await _context.Producao
                .Include(p => p.cooperado)
                .Include(p => p.produto)
                .FirstOrDefaultAsync(m => m.id == id);
            if (producao == null)
            {
                return NotFound();
            }

            return View(producao);
        }

        // POST: Producoes/Delete/5
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
