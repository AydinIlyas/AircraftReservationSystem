using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Entity.Entities
{
    public class Country
    {
        public Country(int ıd, string name, string code, ICollection<City> cities)
        {
            Id = ıd;
            this.name = name;
            this.code = code;
            this.cities = cities;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string code { get; set; }

        public ICollection<City> cities { get; set; }


    }
}
