using AircraftReservationSystem.Areas.AirlineUser.Services;
using AircraftReservationSystem.Areas.AirlineUser.Services.Interfaces;
using AircraftReservationSystem.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AircraftReservationSystem.Areas.AirlineUser.Controllers
{
    [Area("AirlineUser")]
    public class AircraftController : Controller
    {
        private readonly IAircraftService _aircraftService;

        public AircraftController(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }

        public ActionResult Index()
        {
            var aircrafts=_aircraftService.GetAircraftVMs();
            return View(aircrafts);
        }

        public IActionResult AddAircraft()
        {
            AircraftVM aircraftVM= new AircraftVM();
            return View(aircraftVM);
        }

        [HttpPost]
        public IActionResult AddAircraft(AircraftVM aircraftVM)
        {
            _aircraftService.AddAircraft(aircraftVM);
            TempData["CreatedFlightSuccessfully"] = $"Created {aircraftVM.Id} successfully";
            return RedirectToAction(nameof(Index));
        }

    }
}
