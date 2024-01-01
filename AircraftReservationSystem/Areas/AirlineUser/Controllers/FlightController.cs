using AircraftReservationSystem.Areas.AirlineUser.Services.Interfaces;
using AircraftReservationSystem.Models.ViewModels;
using AircraftReservationSystem.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AircraftReservationSystem.Areas.AirlineUser.Controllers
{
    [Area("AirlineUser")]
    [Authorize(Roles = ROLES.Role_Admin + "," + ROLES.Role_Airline_User)]

    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        public IActionResult Index()
        {
            var flights=_flightService.GetFlights();
            return View(flights);
        }
        [HttpGet]
        public IActionResult AddFlight()
        {
            ViewBag.Airports = _flightService.GetAirportSelectList();
            ViewBag.Aircrafts = _flightService.GetAircraftSelectList();
            return View();
        }

        [HttpPost]
        public IActionResult AddFlight(FlightInformation flightViewModel)
        {
            _flightService.AddFlight(flightViewModel);
            TempData["CreatedFlightSuccessfully"] = $"Created {flightViewModel.FlightNumber} successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
