using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Entity.Entities
{
    public class Airport
    {
        public Airport(int ıd, string name, string airportCode, int districtId, District district, ICollection<Flight> flights)
        {
            Id = ıd;
            this.name = name;
            this.airportCode = airportCode;
            this.districtId = districtId;
            this.district = district;
            this.flights = flights;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string airportCode { get; set; }

        [ForeignKey("district")]
        public int districtId { get; set; }

        public District district { get; set; }

        public ICollection<Flight> flights { get; set; }




    }
}
