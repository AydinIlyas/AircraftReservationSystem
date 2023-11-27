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
        public City(int ıd, string name, string code, int countryId, Country country, ICollection<District> districts)
        {
            Id = ıd;
            this.name = name;
            this.code = code;
            this.countryId = countryId;
            this.country = country;
            this.districts = districts;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string code { get; set; }

        [ForeignKey("country")]
        public int countryId { get; set; }

        public Country country { get; set; }

        public ICollection<District> districts { get; set; }

    }
}
