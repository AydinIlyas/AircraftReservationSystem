using AircraftReservationSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AircraftReservationSystem.Areas.AirlineUser.Services.Interfaces
{
    public interface IFlightService
    {
        List<FlightInformation> GetFlights();

        bool AddFlight(FlightInformation flightInformation);

        SelectList GetAircraftSelectList();
        SelectList GetAirportSelectList();
    }
}
