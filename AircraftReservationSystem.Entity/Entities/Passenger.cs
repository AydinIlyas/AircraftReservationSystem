using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Entity.Entities
{
    public class Passenger
    {

        public Passenger(int id, string firstname, string lastname, string passportNumber, string email, string phoneNumber, DateTime birthDate)
        {
            Id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.passportNumber = passportNumber;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.birthDate = birthDate;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2,ErrorMessage = "Your name must be between 2-50 characters!")]
        public string firstname {  get; set; }
        
        [Required]
        public string lastname { get; set; }
        
        [Required]
        public string passportNumber {  get; set; }
        
        [Required]
        [EmailAddress(ErrorMessage ="Enter a valid email adress!")]
        public string email {  get; set; }
        
        [Required]
        [Phone(ErrorMessage = "Enter a valid phone number!")]
        public string phoneNumber { get; set; }
        
        [Required]
        public DateTime birthDate { get; set; }

        public ICollection<SoldTicket> soldTickets { get; set; }

    }
}
