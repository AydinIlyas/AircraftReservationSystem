using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Models
{
    public class District
    {
        public District()
        {
        }

        public District(int id, string name, string code, City city, int cityId, ICollection<Airport> airports)
        {
            Id = id;
            Name = name;
            Code = code;
            City = city;
            CityId = cityId;
            Airports = airports;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        public string Code { get; set; }

        public City City { get; set; }
        public int CityId { get; set; }

        public ICollection<Airport> Airports { get; set; }
    }
}
