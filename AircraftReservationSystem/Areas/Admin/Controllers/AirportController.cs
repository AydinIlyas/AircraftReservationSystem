using AircraftReservationSystem.Areas.Admin.Services;
using AircraftReservationSystem.Areas.Admin.Services.Interfaces;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using AircraftReservationSystem.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AircraftReservationSystem.Areas.Admin.Controllers
{
    [Authorize(Roles =ROLES.Role_Admin)]
    [Area("Admin")]
    public class AirportController : Controller
    {
        private readonly IAirportService airportService;
        private readonly ILocationService locationService;
        public AirportController(IAirportService airportService,ILocationService locationService)
        {
            this.airportService = airportService;
            this.locationService = locationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var airports=airportService.GetAirports();
            return View("AirportList",airports);
        }

        public IActionResult AddAirport() {
            var viewModel = new AirportViewModel();
            ViewBag.Countries = locationService.GetCountries();
            ViewBag.Cities = locationService.GetCities();
            ViewBag.Districts = locationService.GetDistricts();
            return View("AddAirport",viewModel);
        }
        [HttpPost]
        public IActionResult AddAirport(AirportViewModel airportViewModel)
        {
            airportService.CreateAirport(airportViewModel);
            return RedirectToAction(nameof(Index));
        }

        //private List<Country> GetCountries()
        //{
        //    return locationService.GetCountries();
        //}
        //private List<City> GetCities()
        //{
        //    return locationService.GetCities();
        //}
        //private List<District> GetDistricts()
        //{
        //    return locationService.GetDistricts();
        //}
    }
}
