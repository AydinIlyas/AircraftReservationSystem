using AircraftReservationSystem.Models;

namespace AircraftReservationSystem.Areas.Admin.Services.Interfaces
{
    public interface ILocationService
    {
        List<Country> GetCountries();
        List<City> GetCities();
        List<District> GetDistricts();

    }
}
