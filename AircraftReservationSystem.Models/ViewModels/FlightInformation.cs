using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AircraftReservationSystem.Models.ViewModels
{
    public class FlightInformation
    {
        public FlightInformation()
        {
        }

        public FlightInformation(int id, string flightNumber, DateTime departureDate, DateTime arrivalDate, int duration, float price, float businessPrice, int aircraftId, string aircraftName, int departureAirportId, string departureAirportName, int arrivalAirportId, string arrivalAirportName)
        {
            Id = id;
            FlightNumber = flightNumber;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            Duration = duration;
            Price = price;
            BusinessPrice = businessPrice;
            AircraftId = aircraftId;
            AircraftName = aircraftName;
            DepartureAirportId = departureAirportId;
            DepartureAirportName = departureAirportName;
            ArrivalAirportId = arrivalAirportId;
            ArrivalAirportName = arrivalAirportName;
        }

        public int Id { get; set; }
        public string FlightNumber { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ArrivalDate { get; set; }

        public int Duration { get; set; }

        public float Price { get; set; }

        public float BusinessPrice { get; set; }
        public int AircraftId { get; set; }
        public string AircraftName { get; set; }
        public int DepartureAirportId { get; set; }
        public string DepartureAirportName { get; set; }
        public int ArrivalAirportId { get; set; }
        public string ArrivalAirportName { get; set; }

    }
}
