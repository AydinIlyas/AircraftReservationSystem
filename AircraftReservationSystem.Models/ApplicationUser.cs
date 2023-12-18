using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }

        public ApplicationUser(string firstname, string lastname, string passportNumber, DateTime birthDate, string? airlineName, ICollection<SoldTicket>? soldTickets)
        {
            Firstname = firstname;
            Lastname = lastname;
            PassportNumber = passportNumber;
            BirthDate = birthDate;
            AirlineName = airlineName;
            SoldTickets = soldTickets;
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

        public string? AirlineName {  get; set; }
		public ICollection<SoldTicket>? SoldTickets { get; set; }

    }
}
