using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;

namespace AircraftReservationSystem.Areas.AirlineUser.Services.Interfaces
{
    public interface IAircraftService
    {
        void AddAircraft(AircraftVM aircraftVM);
        List<AircraftVM> GetAircraftVMs();
    }
}
