using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Entity.Entities
{
    public class District
    {
        public District(int ıd, string name, string code, int cityId, City city, ICollection<Airport> airports)
        {
            Id = ıd;
            this.name = name;
            this.code = code;
            this.cityId = cityId;
            this.city = city;
            this.airports = airports;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string name { get; set; }


        [Required]
        public string code { get; set; }

        [ForeignKey("city")]
        public int cityId { get; set; }

        public City city { get; set; }

        public ICollection<Airport> airports { get; set; }



    }
}
