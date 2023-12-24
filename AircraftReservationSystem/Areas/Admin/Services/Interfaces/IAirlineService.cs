using AircraftReservationSystem.Models;

namespace AircraftReservationSystem.Areas.Admin.Services.Interfaces
{
    public interface IAirlineService
    {
        void AddAirline(Airline airline);
        IEnumerable<Airline> GetAirlines();
    }
}
