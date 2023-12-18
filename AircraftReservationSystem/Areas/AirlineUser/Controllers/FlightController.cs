using AircraftReservationSystem.Areas.AirlineUser.Services.Interfaces;
using AircraftReservationSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AircraftReservationSystem.Areas.AirlineUser.Controllers
{
    [Area("AirlineUser")]
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

        public IActionResult AddFlight()
        {
            FlightInformation flightInformation=new FlightInformation();
            return View(flightInformation);
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
