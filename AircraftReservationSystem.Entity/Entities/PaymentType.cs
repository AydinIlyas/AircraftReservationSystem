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
        public PaymentType()
        {
        }

        public PaymentType(int id, string paymentTypeName, ICollection<PaymentInformation> paymentInformation)
        {
            Id = id;
            PaymentTypeName = paymentTypeName;
            PaymentInformations = paymentInformation;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string PaymentTypeName{ get; set; }

        public ICollection<PaymentInformation>PaymentInformations { get; set; }

    }
}
