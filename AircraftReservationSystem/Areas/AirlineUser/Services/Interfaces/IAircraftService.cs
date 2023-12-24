using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AircraftReservationSystem.Areas.AirlineUser.Services.Interfaces
{
    public interface IAircraftService
    {
        void AddAircraft(AircraftVM aircraftVM);
        List<AircraftVM> GetAircraftVMs();
        SelectList GetAircraftTypeSelectList();
        SelectList GetAirlineTypeSelectList();
    }
}
