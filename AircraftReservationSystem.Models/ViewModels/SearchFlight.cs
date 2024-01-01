using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Models.ViewModels
{
    public class SearchFlight
    {
        public SearchFlight()
        {
            IsOneWay = true;
        }

        public SearchFlight(bool isOneWay, string? departureAirport, int departureAirportId, string? arrivalAirport, int arrivalAirportId, DateTime? outboundFlightDate, DateTime? returnFlightDate)
        {
            IsOneWay = isOneWay;
            DepartureAirport = departureAirport;
            DepartureAirportId = departureAirportId;
            ArrivalAirport = arrivalAirport;
            ArrivalAirportId = arrivalAirportId;
            OutboundFlightDate = outboundFlightDate;
            ReturnFlightDate = returnFlightDate;
        }

        public bool IsOneWay {  get; set; }
        [Required]
        public String? DepartureAirport {  get; set; }
        
        public int DepartureAirportId {  get; set; }

        [Required]
        public String? ArrivalAirport {  get; set; }

        public int ArrivalAirportId { get; set; }

        [Required]
        public DateTime? OutboundFlightDate {  get; set; }

        public DateTime? ReturnFlightDate {  get; set; }


    }
}
