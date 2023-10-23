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
    public class DataPetugasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DataPetugasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DataPetugas
        public async Task<IActionResult> Index()
        {
              return _context.DataPetugas != null ? 
                          View(await _context.DataPetugas.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DataPetugas'  is null.");
        }

        // GET: DataPetugas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DataPetugas == null)
            {
                return NotFound();
            }

            var dataPetuga = await _context.DataPetugas
                .FirstOrDefaultAsync(m => m.Nim == id);
            if (dataPetuga == null)
            {
                return NotFound();
            }

            return View(dataPetuga);
        }

        // GET: DataPetugas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataPetugas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nim,Nama,Prodi,NoTelp,Status")] DataPetuga dataPetuga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataPetuga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataPetuga);
        }

        // GET: DataPetugas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DataPetugas == null)
            {
                return NotFound();
            }

            var dataPetuga = await _context.DataPetugas.FindAsync(id);
            if (dataPetuga == null)
            {
                return NotFound();
            }
            return View(dataPetuga);
        }

        // POST: DataPetugas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nim,Nama,Prodi,NoTelp,Status")] DataPetuga dataPetuga)
        {
            if (id != dataPetuga.Nim)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataPetuga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataPetugaExists(dataPetuga.Nim))
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
            return View(dataPetuga);
        }

        // GET: DataPetugas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DataPetugas == null)
            {
                return NotFound();
            }

            var dataPetuga = await _context.DataPetugas
                .FirstOrDefaultAsync(m => m.Nim == id);
            if (dataPetuga == null)
            {
                return NotFound();
            }

            return View(dataPetuga);
        }

        // POST: DataPetugas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DataPetugas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DataPetugas'  is null.");
            }
            var dataPetuga = await _context.DataPetugas.FindAsync(id);
            if (dataPetuga != null)
            {
                _context.DataPetugas.Remove(dataPetuga);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataPetugaExists(string id)
        {
          return (_context.DataPetugas?.Any(e => e.Nim == id)).GetValueOrDefault();
        }
    }
}
