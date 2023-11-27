using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Entity.Entities
{
    public class PaymentType
    {
        public PaymentType(int ıd, string paymentType, ICollection<PaymentInformation> paymentInformations)
        {
            Id = ıd;
            this.paymentType = paymentType;
            this.paymentInformations = paymentInformations;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string paymentType{ get; set; }

        public ICollection<PaymentInformation> paymentInformations { get; set; }


    }
}
