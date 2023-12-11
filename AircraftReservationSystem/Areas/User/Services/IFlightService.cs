using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;

namespace AircraftReservationSystem.Areas.User.Services
{
    public interface IFlightService
    {
        IEnumerable<FlightVM> FindFlights(TravelData travelData);
    }
}
