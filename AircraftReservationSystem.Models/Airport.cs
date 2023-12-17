using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Models
{
    public class Airport
    {
        public Airport()
        {
        }

        public Airport(int id, string name, string airportCode, ICollection<Flight> departures, ICollection<Flight> arrivals, District district, int districtId)
        {
            Id = id;
            Name = name;
            AirportCode = airportCode;
            Departures = departures;
            Arrivals = arrivals;
            District = district;
            DistrictId = districtId;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string AirportCode { get; set; }
        [InverseProperty("DepartureAirport")]
        public ICollection<Flight> Departures { get; set; }
        [InverseProperty("ArrivalAirport")]

        public ICollection<Flight> Arrivals { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }



    }
}
