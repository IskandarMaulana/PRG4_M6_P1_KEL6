using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRG4_M6_P1_KEL6.Models;

namespace PRG4_M6_P1_KEL6.Controllers
{
    public class PengumumenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PengumumenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pengumumen
        public async Task<IActionResult> Index()
        {
              return _context.Pengumumen != null ? 
                          View(await _context.Pengumumen.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Pengumumen'  is null.");
        }

        // GET: Pengumumen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pengumumen == null)
            {
                return NotFound();
            }

            var pengumuman = await _context.Pengumumen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pengumuman == null)
            {
                return NotFound();
            }

            return View(pengumuman);
        }

        // GET: Pengumumen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pengumumen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NamaPengumuman,JenisPengumuman,IsiPengumuman")] Pengumuman pengumuman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pengumuman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pengumuman);
        }

        // GET: Pengumumen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pengumumen == null)
            {
                return NotFound();
            }

            var pengumuman = await _context.Pengumumen.FindAsync(id);
            if (pengumuman == null)
            {
                return NotFound();
            }
            return View(pengumuman);
        }

        // POST: Pengumumen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NamaPengumuman,JenisPengumuman,IsiPengumuman")] Pengumuman pengumuman)
        {
            if (id != pengumuman.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pengumuman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PengumumanExists(pengumuman.Id))
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
            return View(pengumuman);
        }

        // GET: Pengumumen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pengumumen == null)
            {
                return NotFound();
            }

            var pengumuman = await _context.Pengumumen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pengumuman == null)
            {
                return NotFound();
            }

            return View(pengumuman);
        }

        // POST: Pengumumen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pengumumen == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pengumumen'  is null.");
            }
            var pengumuman = await _context.Pengumumen.FindAsync(id);
            if (pengumuman != null)
            {
                _context.Pengumumen.Remove(pengumuman);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PengumumanExists(int id)
        {
          return (_context.Pengumumen?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
