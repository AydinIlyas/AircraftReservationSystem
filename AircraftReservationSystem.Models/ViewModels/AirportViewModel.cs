using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int? CountryId { get; set; } = 1;
        public int? CityId { get; set; } = 1;
        public int? DistrictId { get; set; } = 1;
    }
}
