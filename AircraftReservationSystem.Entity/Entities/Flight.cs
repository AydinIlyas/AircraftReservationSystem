using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Entity.Entities
{
    public class Flight
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string fligthNumber { get; set; }

        [Required]
        public DateTime departureDate { get; set; }

        [Required]
        public DateTime arrivalDate { get; set; }

        [Required]
        public int duration { get; set; }

        [Required]
        public float price { get; set; }

        public float businessPrice { get; set; }

        [Required]
        public bool isDisabledFlight { get; set; }

        [ForeignKey("departureAirport")]
        public int departureAirportId { get; set; }

        [ForeignKey("arrivalAirport")]
        public int arrivalAirportId { get; set; }

        //[ForeignKey("")]
        //public int aircraftId { get; set; }

        public ICollection<FlightTicket> flightTickets { get; set; }

        public Airport departureAirport { get; set; }

        public Airport arrivalAirport { get; set; }

    }
}
