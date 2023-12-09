using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Models
{
    public class Passenger : IdentityUser
    {
        public Passenger()
        {
        }

        public Passenger(string firstname, string lastname, string passportNumber, DateTime birthDate, ICollection<SoldTicket> soldTicket)
        {
            Firstname = firstname;
            Lastname = lastname;
            PassportNumber = passportNumber;
            BirthDate = birthDate;
            SoldTickets = soldTicket;
        }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Your name must be between 2-50 characters!")]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string PassportNumber { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public ICollection<SoldTicket> SoldTickets { get; set; }

    }
}
