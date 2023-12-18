using AircraftReservationSystem.DataAccess.Data;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.Utility;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AircraftReservationSystem.Models.ViewModels;
using AircraftReservationSystem.Areas.Admin.Services;
using AircraftReservationSystem.Areas.Admin.Services.Interfaces;

namespace AircraftReservationSystem.Areas.Admin.Controllers
{
    [Authorize(Roles =ROLES.Role_Admin)]
    [Area("Admin")]
    public class UserController : Controller
    {
		private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
			var users = _userService.GetAllPassengers();
            return View(users);
        }

		public IActionResult Edit(string? id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}
            ApplicationUserViewModel passengerVM = _userService.GetPassenger(id);
			
			return View(passengerVM);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditAsync(ApplicationUserViewModel passengerVM)
		{
			// TODO: Edit does not work
			if (ModelState.IsValid)
			{
                Task<bool> success=_userService.UpdatePassengerAsync(passengerVM);
                if (success.GetAwaiter().GetResult())
                {
                    TempData["UpdateUserSuccessMessage"] = $"User '{passengerVM.Email}' updated successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateUserFailMessage"] = $"User '{passengerVM.Email}' updated successfully.";
                    return View(passengerVM);
                }
            }
			TempData["error"] = "Failed to update user. Modelstate is invalid.";
			return View(passengerVM);
		}
        public IActionResult DeleteConfirmed(string id)
        {
            var user = _userService.GetPassengerById(id);

            if (user == null)
            {
                return NotFound();
            }

            Task<bool> success=_userService.DeleteUser(user);
            if (success.GetAwaiter().GetResult())
            {
                TempData["DeleteUserSuccessMessage"] = $"User: '{user.UserName}' deleted successfully.";
            }
            else
            {
                TempData["DeleteUserFailMessage"] = $"User: '{user.UserName}' delete failed.";
            }
            return RedirectToAction("Index");

        }
    }
}
