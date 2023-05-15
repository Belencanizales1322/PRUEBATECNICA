using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HBCR.APPMVC.Models;

namespace HBCR.APPMVC.Controllers
{
    public class MascotumsController : Controller
    {
        private readonly HBCRBDContext _context;

        public MascotumsController(HBCRBDContext context)
        {
            _context = context;
        }

        // GET: Mascotums
        public async Task<IActionResult> Index()
        {
              return _context.Mascota != null ? 
                          View(await _context.Mascota.ToListAsync()) :
                          Problem("Entity set 'HBCRBDContext.Mascota'  is null.");
        }

        // GET: Mascotums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mascota == null)
            {
                return NotFound();
            }

            var mascotum = await _context.Mascota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascotum == null)
            {
                return NotFound();
            }

            return View(mascotum);
        }

        // GET: Mascotums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mascotums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Fecha,Edad,Color,Sexo,Especie,Raza,Peso,Temperatura")] Mascotum mascotum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mascotum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mascotum);
        }

        // GET: Mascotums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mascota == null)
            {
                return NotFound();
            }

            var mascotum = await _context.Mascota.FindAsync(id);
            if (mascotum == null)
            {
                return NotFound();
            }
            return View(mascotum);
        }

        // POST: Mascotums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Fecha,Edad,Color,Sexo,Especie,Raza,Peso,Temperatura")] Mascotum mascotum)
        {
            if (id != mascotum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
            
                    _context.Update(mascotum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotumExists(mascotum.Id))
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
            return View(mascotum);
        }

        // GET: Mascotums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mascota == null)
            {
                return NotFound();
            }

            var mascotum = await _context.Mascota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascotum == null)
            {
                return NotFound();
            }

            return View(mascotum);
        }

        // POST: Mascotums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mascota == null)
            {
                return Problem("Entity set 'HBCRBDContext.Mascota'  is null.");
            }
            var mascotum = await _context.Mascota.FindAsync(id);
            if (mascotum != null)
            {
                _context.Mascota.Remove(mascotum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotumExists(int id)
        {
          return (_context.Mascota?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
