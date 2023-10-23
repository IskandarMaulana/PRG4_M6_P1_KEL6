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
    public class TransaksisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransaksisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transaksis
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Transaksis.Include(t => t.NimNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Transaksis/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Transaksis == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis
                .Include(t => t.NimNavigation)
                .FirstOrDefaultAsync(m => m.Nim == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // GET: Transaksis/Create
        public IActionResult Create()
        {
            ViewData["Nim"] = new SelectList(_context.DataPetugas, "Nim", "Nim");
            return View();
        }

        // POST: Transaksis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nim,Tanggal,Jobdesk,WaktuSholat")] Transaksi transaksi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaksi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Nim"] = new SelectList(_context.DataPetugas, "Nim", "Nim", transaksi.Nim);
            return View(transaksi);
        }

        // GET: Transaksis/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Transaksis == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis.FindAsync(id);
            if (transaksi == null)
            {
                return NotFound();
            }
            ViewData["Nim"] = new SelectList(_context.DataPetugas, "Nim", "Nim", transaksi.Nim);
            return View(transaksi);
        }

        // POST: Transaksis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nim,Tanggal,Jobdesk,WaktuSholat")] Transaksi transaksi)
        {
            if (id != transaksi.Nim)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaksi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaksiExists(transaksi.Nim))
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
            ViewData["Nim"] = new SelectList(_context.DataPetugas, "Nim", "Nim", transaksi.Nim);
            return View(transaksi);
        }

        // GET: Transaksis/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Transaksis == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis
                .Include(t => t.NimNavigation)
                .FirstOrDefaultAsync(m => m.Nim == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // POST: Transaksis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Transaksis == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Transaksis'  is null.");
            }
            var transaksi = await _context.Transaksis.FindAsync(id);
            if (transaksi != null)
            {
                _context.Transaksis.Remove(transaksi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaksiExists(string id)
        {
          return (_context.Transaksis?.Any(e => e.Nim == id)).GetValueOrDefault();
        }
    }
}
