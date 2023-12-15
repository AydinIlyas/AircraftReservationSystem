using AircraftReservationSystem.DataAccess.Data;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.Utility;
using BulkyBook.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AircraftReservationSystem.Areas.Admin.Controllers
{
    [Authorize(Roles =ROLES.Role_Admin)]
    [Area("Admin")]
    public class UserController : Controller
    {
		private IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public IActionResult Index()
        {
            var users = _unitOfWork.Passenger.GetAll().ToList();
            return View(users);
        }

		public IActionResult Edit(string? id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}

			var passenger = _unitOfWork.Passenger.GetFirstOrDefault(x => x.Id == id);

			if (passenger == null)
			{
				return NotFound();
			}

			return View(passenger);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Passenger obj)
		{
			// TODO: Edit does not work
			if (ModelState.IsValid)
			{
				_unitOfWork.Passenger.Update(obj);
				_unitOfWork.Save();
				return RedirectToAction("Index");
			}
			TempData["error"] = "Failed to update user. Modelstate is invalid.";
			return View(obj);
		}
		// GET: Admin/User/Delete/5
		public IActionResult Delete(string? id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}

			var user = _unitOfWork.Passenger.GetFirstOrDefault(u=>u.Id==id);

			if (user == null)
			{
				return NotFound();
			}

			return View(user);
		}


		// POST: Admin/User/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(Passenger obj)
		{ 
			_unitOfWork.Passenger.Delete(obj);
			_unitOfWork.Save();
			return RedirectToAction("Index");
		}
	}
}
