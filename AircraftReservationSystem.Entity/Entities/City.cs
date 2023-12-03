using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Entity.Entities
{
    public class City
    {
        public City()
        {
        }

        public City(int id, string name, string code, Country country, int countryId, ICollection<District> districts)
        {
            Id = id;
            Name = name;
            Code = code;
            Country = country;
            CountryId = countryId;
            Districts = districts;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }  

        public ICollection<District> Districts { get; set; }

    }
}
