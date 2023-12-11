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

        public AirportViewModel(Airport airport, int countryId, int cityId, int districtId, List<Country> countries, List<City> cities, List<District> districts, int selectedDistrict, int selectedCity, int selectedCountry)
        {
            Airport = airport;
            CountryId = countryId;
            CityId = cityId;
            DistrictId = districtId;
            Countries = countries;
            Cities = cities;
            Districts = districts;
            SelectedDistrict = selectedDistrict;
            SelectedCity = selectedCity;
            SelectedCountry = selectedCountry;
        }

        public Airport? Airport { get; set; }
        public int? CountryId { get; set; } = 1;
        public int? CityId { get; set; } = 1;
        public int? DistrictId { get; set; } = 1;
        public List<Country>? Countries { get; set; }
        public List<City>? Cities { get; set; }
        public List<District>? Districts { get; set; }
        public int? SelectedDistrict {get; set;}
        public int? SelectedCity {get; set;}
        public int? SelectedCountry {get; set;}
    }
}
