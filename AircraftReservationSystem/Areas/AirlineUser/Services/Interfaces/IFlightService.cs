using AircraftReservationSystem.Models.ViewModels;

namespace AircraftReservationSystem.Areas.AirlineUser.Services.Interfaces
{
    public interface IFlightService
    {
        List<FlightInformation> GetFlights();

        bool AddFlight(FlightInformation flightInformation);
    }
}
