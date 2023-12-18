using AircraftReservationSystem.Areas.Admin.Services.Interfaces;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AircraftReservationSystem.Areas.Admin.Services
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AirportService> _logger;

        public UserService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, ILogger<AirportService> logger)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<bool> DeleteUser(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public List<ApplicationUserViewModel> GetAllPassengers()
        {
            var passengers=_unitOfWork.Passenger.GetAll().ToList();
            var applicationUserVMs = passengers.Select(passenger => new ApplicationUserViewModel
            {
                Id=passenger.Id,
                Firstname = passenger.Firstname,
                Lastname = passenger.Lastname,
                Email = passenger.Email,
                Role = _userManager.GetRolesAsync(passenger).Result.ToList()[0],
                // Other properties as needed in your view model
            }).ToList();
            return applicationUserVMs;
        }

        public ApplicationUserViewModel? GetPassenger(string id)
        {
            ApplicationUser passenger = _unitOfWork.Passenger.GetFirstOrDefault(x => x.Id == id);

            if (passenger == null)
            {
                return null;
            }
            ApplicationUserViewModel passengerVM = new ApplicationUserViewModel
            {
                Firstname = passenger.Firstname,
                Lastname = passenger.Lastname,
                Email = passenger.Email
            };
            return passengerVM;
        }

        public ApplicationUser? GetPassengerById(string id)
        {
            ApplicationUser passenger= _unitOfWork.Passenger.GetFirstOrDefault(x => x.Id.Equals(id));
            if(passenger==null)
            {
                _logger.LogWarning("User not found! User Id: {Id}", id);
                return null;
            }
            return passenger;
        }

        public async Task<bool> UpdatePassengerAsync(ApplicationUserViewModel passengerVM)
        {
            ApplicationUser passenger = _unitOfWork.Passenger.GetFirstOrDefault(x => x.Id == passengerVM.Id);
            passenger.Firstname = passengerVM.Firstname;
            passenger.Lastname = passengerVM.Lastname;
            passenger.Email = passengerVM.Email;
            passenger.NormalizedEmail = passengerVM.Email.ToUpper();
            passenger.UserName = passengerVM.Email;

            var result = await _userManager.UpdateAsync(passenger);
            return result.Succeeded;
        }
    }
}
