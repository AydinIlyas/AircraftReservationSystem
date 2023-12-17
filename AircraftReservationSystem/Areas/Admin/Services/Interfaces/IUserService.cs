using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;

namespace AircraftReservationSystem.Areas.Admin.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> DeleteUser(Passenger user);
        List<Passenger> GetAllPassengers();
        PassengerViewModel? GetPassenger(string id);
        Passenger? GetPassengerById(string id);
        Task<bool> UpdatePassengerAsync(PassengerViewModel passengerVM);
    }
}
