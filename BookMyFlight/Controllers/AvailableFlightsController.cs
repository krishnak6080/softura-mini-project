using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookMyFlight.Models;

namespace BookMyFlight.Controllers
{
    public class AvailableFlightsController : Controller
    {
        private readonly BookMyFlightContext _context;

        public AvailableFlightsController(BookMyFlightContext context)
        {
            _context = context;
        }

        // GET: AvailableFlights
        public async Task<IActionResult> Index()
        {
              return View(await _context.AvailableFlights.ToListAsync());
        }

        // GET: AvailableFlights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AvailableFlights == null)
            {
                return NotFound();
            }

            var availableFlight = await _context.AvailableFlights
                .FirstOrDefaultAsync(m => m.Sno == id);
            if (availableFlight == null)
            {
                return NotFound();
            }

            return View(availableFlight);
        }

        // GET: AvailableFlights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AvailableFlights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sno,FromWhere,WhereTo,Class,DepartureDate,AvailableSeates,Price")] AvailableFlight availableFlight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(availableFlight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(availableFlight);
        }

        // GET: AvailableFlights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AvailableFlights == null)
            {
                return NotFound();
            }

            var availableFlight = await _context.AvailableFlights.FindAsync(id);
            if (availableFlight == null)
            {
                return NotFound();
            }
            return View(availableFlight);
        }

        // POST: AvailableFlights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sno,FromWhere,WhereTo,Class,DepartureDate,AvailableSeates,Price")] AvailableFlight availableFlight)
        {
            if (id != availableFlight.Sno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(availableFlight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvailableFlightExists(availableFlight.Sno))
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
            return View(availableFlight);
        }

        // GET: AvailableFlights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AvailableFlights == null)
            {
                return NotFound();
            }

            var availableFlight = await _context.AvailableFlights
                .FirstOrDefaultAsync(m => m.Sno == id);
            if (availableFlight == null)
            {
                return NotFound();
            }

            return View(availableFlight);
        }

        // POST: AvailableFlights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AvailableFlights == null)
            {
                return Problem("Entity set 'BookMyFlightContext.AvailableFlights'  is null.");
            }
            var availableFlight = await _context.AvailableFlights.FindAsync(id);
            if (availableFlight != null)
            {
                _context.AvailableFlights.Remove(availableFlight);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvailableFlightExists(int id)
        {
          return _context.AvailableFlights.Any(e => e.Sno == id);
        }
    }
}
