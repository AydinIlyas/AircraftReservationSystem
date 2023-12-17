using AircraftReservationSystem.Areas.Admin.Services;
using AircraftReservationSystem.Areas.Admin.Services.Interfaces;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using AircraftReservationSystem.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AircraftReservationSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = ROLES.Role_Admin)]
    [Area("Admin")]
    public class AirportController : Controller
    {
        private readonly IAirportService _airportService;
        public AirportController(IAirportService airportService)
        {
            _airportService = airportService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var airports = _airportService.GetAirports();
            return View("AirportList", airports);
        }

        public IActionResult AddAirport()
        {
            var viewModel = new AirportViewModel();
            return View("AddAirport", viewModel);
        }

        [HttpPost]
        public IActionResult AddAirport(AirportViewModel airportViewModel)
        {
            _airportService.CreateAirport(airportViewModel);
            TempData["CreatedAirportSuccessfully"]= $"Created {airportViewModel?.Airport?.Name} successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditAirport(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Airport airport = _airportService.GetAirportById((int)id);

            if (airport == null)
            {
                return NotFound();
            }
            AirportViewModel viewModel = new AirportViewModel
            {
                Airport = airport,
                DistrictId = airport.DistrictId
            };

            return View("EditAirport", viewModel);
        }


        public IActionResult DeleteConfirmed(int id)
        {
            var airport = _airportService.GetAirportById(id);

            if (airport == null)
            {
                return NotFound();
            }

            _airportService.DeleteAirport(airport);

            TempData["DeleteAirportSuccessMessage"] = $"Airport '{airport.Name}' deleted successfully.";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateAirport(AirportViewModel airport)
        {
            if (airport == null)
            {
                return NotFound();
            }

            if (airport.Id != null&&ModelState.IsValid)
            {

                _airportService.UpdateAirport(airport.ToAirport());

                TempData["UpdatedAirportSuccessMessage"] = $"Airport '{airport.Name}' updated successfully.";

                return RedirectToAction("Index");
            }
            TempData["FailedAirportUpdateMessage"] = $"An error occurred while updating the airport '{airport.Name}'.";
            return RedirectToAction("Index");

        }




    }
}
