using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;

namespace AircraftReservationSystem.Areas.AirlineUser.Services.Interfaces
{
    public interface IAircraftTypeService
    {
        void AddAircraftType(AircraftTypeVM aircraftTypeVM);
        List<AircraftTypeVM> GetAircraftTypeVMs();
        AircraftTypeVM GetAircraftTypeVMById(int id);
        void DeleteAircraftType(int id);
        void UpdateAircraftType(AircraftTypeVM aircraftTypeVM);
    }
}
