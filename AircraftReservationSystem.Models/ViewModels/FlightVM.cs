using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AircraftReservationSystem.Models.ViewModels
{
    public class FlightVM
    {
        public FlightVM()
        {
        }

        public FlightVM(int id,string flightNumber, DateTime departureDate, DateTime arrivalDate, int duration, float price, float businessPrice, Aircraft aircraft, int airCraftId, Airport departureAirport, int departureAirportId, Airport arrivalAirport, int arrivalAirportId)
        {
            Id = id;
            FlightNumber = flightNumber;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            Duration = duration;
            Price = price;
            BusinessPrice = businessPrice;
            Aircraft = aircraft;
            AirCraftId = airCraftId;
            DepartureAirport = departureAirport;
            DepartureAirportId = departureAirportId;
            ArrivalAirport = arrivalAirport;
            ArrivalAirportId = arrivalAirportId;
        }
        public int Id { get; set; }
        public string FlightNumber { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ArrivalDate { get; set; }

        public int Duration { get; set; }

        public float Price { get; set; }

        public float BusinessPrice { get; set; }

        public Aircraft Aircraft { get; set; }
        public int AirCraftId { get; set; }
        public Airport DepartureAirport { get; set; }
        public int DepartureAirportId { get; set; }
        public Airport ArrivalAirport { get; set; }
        public int ArrivalAirportId { get; set; }
    }
}
