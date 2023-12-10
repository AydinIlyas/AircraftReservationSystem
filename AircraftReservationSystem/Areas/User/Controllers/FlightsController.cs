using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AircraftReservationSystem.DataAccess.Data;
using AircraftReservationSystem.Models;

namespace AircraftReservationSystem.Areas.User.Controllers
{
    [Area("User")]
    public class FlightsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlightsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User/Flights
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Flights.Include(f => f.Aircraft).Include(f => f.ArrivalAirport).Include(f => f.DepartureAirport);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: User/Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Flights == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .Include(f => f.Aircraft)
                .Include(f => f.ArrivalAirport)
                .Include(f => f.DepartureAirport)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: User/Flights/Create
        public IActionResult Create()
        {
            ViewData["AirCraftId"] = new SelectList(_context.Aircrafts, "Id", "Id");
            ViewData["ArrivalAirportId"] = new SelectList(_context.Airports, "Id", "AirportCode");
            ViewData["DepartureAirportId"] = new SelectList(_context.Airports, "Id", "AirportCode");
            return View();
        }

        // POST: User/Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FligthNumber,DepartureDate,ArrivalDate,Duration,Price,BusinessPrice,IsDisabledFlight,AirCraftId,DepartureAirportId,ArrivalAirportId")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AirCraftId"] = new SelectList(_context.Aircrafts, "Id", "Id", flight.AirCraftId);
            ViewData["ArrivalAirportId"] = new SelectList(_context.Airports, "Id", "AirportCode", flight.ArrivalAirportId);
            ViewData["DepartureAirportId"] = new SelectList(_context.Airports, "Id", "AirportCode", flight.DepartureAirportId);
            return View(flight);
        }

        // GET: User/Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Flights == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            ViewData["AirCraftId"] = new SelectList(_context.Aircrafts, "Id", "Id", flight.AirCraftId);
            ViewData["ArrivalAirportId"] = new SelectList(_context.Airports, "Id", "AirportCode", flight.ArrivalAirportId);
            ViewData["DepartureAirportId"] = new SelectList(_context.Airports, "Id", "AirportCode", flight.DepartureAirportId);
            return View(flight);
        }

        // POST: User/Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FligthNumber,DepartureDate,ArrivalDate,Duration,Price,BusinessPrice,IsDisabledFlight,AirCraftId,DepartureAirportId,ArrivalAirportId")] Flight flight)
        {
            if (id != flight.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.Id))
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
            ViewData["AirCraftId"] = new SelectList(_context.Aircrafts, "Id", "Id", flight.AirCraftId);
            ViewData["ArrivalAirportId"] = new SelectList(_context.Airports, "Id", "AirportCode", flight.ArrivalAirportId);
            ViewData["DepartureAirportId"] = new SelectList(_context.Airports, "Id", "AirportCode", flight.DepartureAirportId);
            return View(flight);
        }

        // GET: User/Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Flights == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .Include(f => f.Aircraft)
                .Include(f => f.ArrivalAirport)
                .Include(f => f.DepartureAirport)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: User/Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Flights == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Flights'  is null.");
            }
            var flight = await _context.Flights.FindAsync(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
          return (_context.Flights?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
