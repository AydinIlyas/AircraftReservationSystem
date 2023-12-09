using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Models
{
    public class Country
    {
        public Country()
        {
        }

        public Country(int id, string name, string code, ICollection<City> cities)
        {
            Id = id;
            Name = name;
            Code = code;
            Cities = cities;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public ICollection<City> Cities { get; set; }

    }
}
