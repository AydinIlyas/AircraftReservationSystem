using System;
using System.Collections.Generic;
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
            DepartureAirport = "";
            ArrivalAirport = "";
            OutboundFlightDate = null;
            ReturnFlightDate = null;
        }

        public SearchFlight(bool isOneWay, string departureAirport, string arrivalAirport, DateTime outboundFlightDate, DateTime? returnFlightDate)
        {
            IsOneWay = true;
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
            OutboundFlightDate = outboundFlightDate;
            ReturnFlightDate = returnFlightDate;
        }

        public bool IsOneWay {  get; set; } 
        public string DepartureAirport {  get; set; }
        public string ArrivalAirport {  get; set; }
        public DateTime? OutboundFlightDate {  get; set; }

        public DateTime? ReturnFlightDate {  get; set; }


    }
}
