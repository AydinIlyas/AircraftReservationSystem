using AircraftReservationSystem.Areas.AirlineUser.Services;
using AircraftReservationSystem.Areas.AirlineUser.Services.Interfaces;
using AircraftReservationSystem.Models.ViewModels;
using AircraftReservationSystem.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AircraftReservationSystem.Areas.AirlineUser.Controllers
{
    [Area("AirlineUser")]
    [Authorize(Roles = ROLES.Role_Admin+","+ROLES.Role_Airline_User)]

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
            ViewBag.AircraftTypes=_aircraftService.GetAircraftTypeSelectList();
            ViewBag.Airlines = _aircraftService.GetAirlineTypeSelectList();
            AircraftVM aircraftVM = new AircraftVM();
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
