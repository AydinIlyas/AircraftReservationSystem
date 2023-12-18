using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;

namespace AircraftReservationSystem.Areas.Admin.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> DeleteUser(ApplicationUser user);
        List<ApplicationUserViewModel> GetAllPassengers();
        ApplicationUserViewModel? GetPassenger(string id);
        ApplicationUser? GetPassengerById(string id);
        Task<bool> UpdatePassengerAsync(ApplicationUserViewModel passengerVM);
    }
}
