using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AircraftReservationSystem.Areas.Admin.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> DeleteUser(ApplicationUser user);
        List<ApplicationUserViewModel> GetAllPassengers();
        ApplicationUserViewModel? GetPassenger(string id);
        ApplicationUser? GetPassengerById(string id);
        Task<bool> UpdatePassengerAsync(ApplicationUserViewModel passengerVM);
        Task<bool> AddUser(AddUserModel userModel);
    }
}
