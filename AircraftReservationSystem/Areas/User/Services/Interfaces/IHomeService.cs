using AircraftReservationSystem.Models.ViewModels;

namespace AircraftReservationSystem.Areas.User.Services.Interfaces
{
    public interface IHomeService
    {
        public IEnumerable<FlightInformation> SearchFlights(SearchFlight search);
    }
}
