using AircraftReservationSystem.Areas.User.Services;
using AircraftReservationSystem.Areas.User.Services.Interfaces;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AircraftReservationSystem.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IHomeService homeService, ILogger<HomeController> logger)
        {
            _homeService = homeService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new SearchFlight());
        }
        [HttpPost]
        public IActionResult Index(SearchFlight search)
        {
           if (ModelState.IsValid)
            {
                var flights = _homeService.SearchFlights(search);
                TempData["Flights"] = JsonConvert.SerializeObject(flights);
                return RedirectToAction("Flights");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Flights()
        {
            var flightsJson = TempData["Flights"] as string;

            if (flightsJson == null)
            {
                return RedirectToAction("Index");
            }

            IEnumerable<FlightInformation> flights = JsonConvert.DeserializeObject<List<FlightInformation>>(flightsJson);

            return View(flights);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}