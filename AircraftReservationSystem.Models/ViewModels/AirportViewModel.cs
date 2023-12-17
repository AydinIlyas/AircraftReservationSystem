using System.Collections.Generic;
using AircraftReservationSystem.Models;

namespace AircraftReservationSystem.Models.ViewModels
{
    public class AirportViewModel
    {
        public AirportViewModel()
        {
        }

        public AirportViewModel(Airport airport, int countryId, int cityId, int districtId)
        {
            Airport = airport;
            CountryId = countryId;
            CityId = cityId;
            DistrictId = districtId;
        }

        public Airport? Airport { get; set; }
        public int Id { get; set; }

        public string Name { get; set; }

        public string AirportCode { get; set; }

        public ICollection<Flight> Departures { get; set; }

        public ICollection<Flight> Arrivals { get; set; }

        public int DistrictId { get; set; }

        public District District { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public Airport ToAirport()
        {
            return new Airport
            {
                Id = Id,
                Name = Name,
                AirportCode = AirportCode,
                Departures = Departures,
                Arrivals = Arrivals,
                DistrictId = DistrictId,
                District = District,
            };
        }

    }
}
