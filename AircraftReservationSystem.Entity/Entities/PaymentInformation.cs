using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Entity.Entities
{
    public class PaymentInformation
    {
        public PaymentInformation()
        {
        }

        public PaymentInformation(int id, string cardNumber, DateTime date, PaymentType paymentType, int paymentTypeId, SoldTicket soldTicket, int soldTicketId)
        {
            Id = id;
            CardNumber = cardNumber;
            Date = date;
            PaymentType = paymentType;
            PaymentTypeId = paymentTypeId;
            SoldTicket = soldTicket;
            SoldTicketId = soldTicketId;
        }

        [Key]
        public int Id{ get; set; }

        [Required] 
        public string CardNumber { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public PaymentType PaymentType { get; set; }
        public int PaymentTypeId { get; set; }

        public SoldTicket SoldTicket { get; set; }
        public int SoldTicketId { get; set; }
        
    }
}
