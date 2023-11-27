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
        public PaymentInformation(int ıd, string cardNumber, DateTime date, int paymentTypeId, PaymentType paymentType, SoldTicket soldTicket)
        {
            Id = ıd;
            this.cardNumber = cardNumber;
            Date = date;
            this.paymentTypeId = paymentTypeId;
            this.paymentType = paymentType;
            SoldTicket = soldTicket;
        }

        [Key]
        public int Id{ get; set; }

        [Required] 
        public string cardNumber { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("paymentType")]
        public int paymentTypeId { get; set; }

        public PaymentType paymentType { get; set; }

        public SoldTicket SoldTicket { get; set; }
        
    }
}
