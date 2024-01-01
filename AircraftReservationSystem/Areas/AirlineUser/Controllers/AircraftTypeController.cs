using AircraftReservationSystem.Areas.AirlineUser.Services;
using AircraftReservationSystem.Areas.AirlineUser.Services.Interfaces;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AircraftReservationSystem.Areas.AirlineUser.Controllers
{
    [Area("AirlineUser")]
    public class AircraftTypeController : Controller
    {
        private readonly IAircraftTypeService _aircraftTypeService;

        public AircraftTypeController(IAircraftTypeService aircraftTypeService)
        {
            _aircraftTypeService = aircraftTypeService;
        }

        public IActionResult Index()
        {
            var aircraftVMs=_aircraftTypeService.GetAircraftTypeVMs();
            return View(aircraftVMs);
        }

        public IActionResult AddAircraftType()
        {
            AircraftTypeVM aircraftTypeVM = new AircraftTypeVM();
            return View("AddAircraftType",aircraftTypeVM);
        }

        [HttpPost]
        public IActionResult AddAircraftType(AircraftTypeVM aircraftTypeVM)
        {
            _aircraftTypeService.AddAircraftType(aircraftTypeVM);
            TempData["CreatedAircraftTypeSuccessfully"] = $"Created {aircraftTypeVM.Type} successfully";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditAircraftType(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AircraftTypeVM aircraftTypeVM = _aircraftTypeService.GetAircraftTypeVMById((int)id);

            if (aircraftTypeVM == null)
            {
                return NotFound();
            }

            return View("EditAircraftType", aircraftTypeVM);
        }


        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _aircraftTypeService.DeleteAircraftType(id);
            }
            catch (NullReferenceException ex)
            {
            TempData["DeleteAirportFailMessage"] = $"AircraftType not found. ID: {id}";

            }
            TempData["DeleteAirportSuccessMessage"] = $"AircraftType deleted successfully. Id: {id}";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateAircraftType(AircraftTypeVM aircraftTypeVM)
        {
            if (aircraftTypeVM == null)
            {
                return NotFound();
            }

            if (aircraftTypeVM.Id != null && ModelState.IsValid)
            {

                _aircraftTypeService.UpdateAircraftType(aircraftTypeVM);

                TempData["UpdatedAirportSuccessMessage"] = $"Aircraft type '{aircraftTypeVM.Type}' updated successfully.";

                return RedirectToAction("Index");
            }
            TempData["FailedAirportUpdateMessage"] = $"An error occurred while updating the aircraft type '{aircraftTypeVM.Type}'.";
            return RedirectToAction("Index");

        }

        [HttpPost]
        public void ForNext(int width, int height)
        {
            TempData["Length"] = 25;
            TempData["Width"] = 6;

        }

    }
}
