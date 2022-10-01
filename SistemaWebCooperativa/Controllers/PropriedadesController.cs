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
    public class PropriedadesController : Controller
    {
        private readonly Contexto _context;

        public PropriedadesController(Contexto context)
        {
            _context = context;
        }

        // GET: Propriedades
        public async Task<IActionResult> Index()
        {
              return View(await _context.Propriedade.ToListAsync());
        }

        // GET: Propriedades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Propriedade == null)
            {
                return NotFound();
            }

            var propriedade = await _context.Propriedade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propriedade == null)
            {
                return NotFound();
            }

            return View(propriedade);
        }

        // GET: Propriedades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Propriedades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome,endereco,bairro,cidade,uf,area")] Propriedade propriedade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propriedade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propriedade);
        }

        // GET: Propriedades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Propriedade == null)
            {
                return NotFound();
            }

            var propriedade = await _context.Propriedade.FindAsync(id);
            if (propriedade == null)
            {
                return NotFound();
            }
            return View(propriedade);
        }

        // POST: Propriedades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome,endereco,bairro,cidade,uf,area")] Propriedade propriedade)
        {
            if (id != propriedade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propriedade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropriedadeExists(propriedade.Id))
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
            return View(propriedade);
        }

        // GET: Propriedades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Propriedade == null)
            {
                return NotFound();
            }

            var propriedade = await _context.Propriedade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propriedade == null)
            {
                return NotFound();
            }

            return View(propriedade);
        }

        // POST: Propriedades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Propriedade == null)
            {
                return Problem("Entity set 'Contexto.Propriedade'  is null.");
            }
            var propriedade = await _context.Propriedade.FindAsync(id);
            if (propriedade != null)
            {
                _context.Propriedade.Remove(propriedade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropriedadeExists(int id)
        {
          return _context.Propriedade.Any(e => e.Id == id);
        }
    }
}
