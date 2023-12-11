using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;

namespace AircraftReservationSystem.Areas.Admin.Services.Interfaces
{
    public interface IAirportService
    {
        IEnumerable<Airport> GetAirports();
        void CreateAirport(AirportViewModel airportViewModel);

    }
}
