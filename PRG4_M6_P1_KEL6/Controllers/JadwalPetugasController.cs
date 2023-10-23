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
    public class JadwalPetugasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JadwalPetugasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JadwalPetugas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JadwalPetugas.Include(j => j.NimNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: JadwalPetugas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JadwalPetugas == null)
            {
                return NotFound();
            }

            var jadwalPetuga = await _context.JadwalPetugas
                .Include(j => j.NimNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jadwalPetuga == null)
            {
                return NotFound();
            }

            return View(jadwalPetuga);
        }

        // GET: JadwalPetugas/Create
        public IActionResult Create()
        {
            ViewData["Nim"] = new SelectList(_context.DataPetugas, "Nim", "Nim");
            return View();
        }

        // POST: JadwalPetugas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nim,Tugas,WaktuTugas")] JadwalPetuga jadwalPetuga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jadwalPetuga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Nim"] = new SelectList(_context.DataPetugas, "Nim", "Nim", jadwalPetuga.Nim);
            return View(jadwalPetuga);
        }

        // GET: JadwalPetugas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JadwalPetugas == null)
            {
                return NotFound();
            }

            var jadwalPetuga = await _context.JadwalPetugas.FindAsync(id);
            if (jadwalPetuga == null)
            {
                return NotFound();
            }
            ViewData["Nim"] = new SelectList(_context.DataPetugas, "Nim", "Nim", jadwalPetuga.Nim);
            return View(jadwalPetuga);
        }

        // POST: JadwalPetugas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nim,Tugas,WaktuTugas")] JadwalPetuga jadwalPetuga)
        {
            if (id != jadwalPetuga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jadwalPetuga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JadwalPetugaExists(jadwalPetuga.Id))
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
            ViewData["Nim"] = new SelectList(_context.DataPetugas, "Nim", "Nim", jadwalPetuga.Nim);
            return View(jadwalPetuga);
        }

        // GET: JadwalPetugas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JadwalPetugas == null)
            {
                return NotFound();
            }

            var jadwalPetuga = await _context.JadwalPetugas
                .Include(j => j.NimNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jadwalPetuga == null)
            {
                return NotFound();
            }

            return View(jadwalPetuga);
        }

        // POST: JadwalPetugas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JadwalPetugas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.JadwalPetugas'  is null.");
            }
            var jadwalPetuga = await _context.JadwalPetugas.FindAsync(id);
            if (jadwalPetuga != null)
            {
                _context.JadwalPetugas.Remove(jadwalPetuga);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JadwalPetugaExists(int id)
        {
          return (_context.JadwalPetugas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
