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
        private readonly IAirportService airportService;
        public AirportController(IAirportService airportService)
        {
            this.airportService = airportService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var airports = airportService.GetAirports();
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
            airportService.CreateAirport(airportViewModel);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditAirport(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Airport airport = airportService.GetAirportById((int)id);

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
            var airport = airportService.GetAirportById(id);

            if (airport == null)
            {
                return NotFound();
            }

            airportService.DeleteAirport(airport);

            TempData["DeleteSuccessMessage"] = $"Airport '{airport.Name}' deleted successfully.";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateAirport(AirportViewModel airport)
        {
            if (airport == null)
            {
                return NotFound();
            }

            if (airport.Id != null)
            {

                airportService.UpdateAirport(airport.ToAirport());

                TempData["UpdatedSuccessMessage"] = $"Airport '{airport.Name}' updated successfully.";

                return RedirectToAction("Index");
            }
            TempData["FailedUpdateMessage"] = $"An error occurred while updating the airport '{airport.Name}'.";
            return RedirectToAction("Index");

        }




    }
}
