using AircraftReservationSystem.Areas.Admin.Services.Interfaces;
using AircraftReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace AircraftReservationSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AirlineController : Controller
    {
        private readonly IAirlineService _airlineService;

        public AirlineController(IAirlineService airlineService)
        {
            _airlineService = airlineService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var airlines=_airlineService.GetAirlines();
            return View(airlines);
        }

        public IActionResult AddAirline()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAirline(Airline airline)
        {
            _airlineService.AddAirline(airline);
            return RedirectToAction(nameof(Index));
        }
    }
}
