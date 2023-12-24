using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Models
{
    public class Flight
    {
        public Flight()
        {
        }

        public Flight(int id, string flightNumber, DateTime departureDate, DateTime arrivalDate, int duration, float price, float businessPrice, bool isDisabledFlight, Aircraft aircraft, int aircraftId, Airport departureAirport, int departureAirportId, Airport arrivalAirport, int arrivalAirportId, ICollection<FlightTicket> flightTickets)
        {
            Id = id;
            FlightNumber = flightNumber;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            Duration = duration;
            Price = price;
            BusinessPrice = businessPrice;
            IsDisabledFlight = isDisabledFlight;
            Aircraft = aircraft;
            AircraftId = aircraftId;
            DepartureAirport = departureAirport;
            DepartureAirportId = departureAirportId;
            ArrivalAirport = arrivalAirport;
            ArrivalAirportId = arrivalAirportId;
            FlightTickets = flightTickets;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FlightNumber { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public float Price { get; set; }

        public float BusinessPrice { get; set; }

        [Required]
        public bool IsDisabledFlight { get; set; }

        [ForeignKey("AircraftId")]
        public Aircraft Aircraft { get; set; }
        public int AircraftId { get; set; }
        [ForeignKey("DepartureAirportId")]
        public Airport DepartureAirport { get; set; }
        public int DepartureAirportId { get; set; }
        [ForeignKey("ArrivalAirportId")]
        public Airport ArrivalAirport { get; set; }
        public int ArrivalAirportId { get; set; }

        public ICollection<FlightTicket> FlightTickets { get; set; }

    }
}
