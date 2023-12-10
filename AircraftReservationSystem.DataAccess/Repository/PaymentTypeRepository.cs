using AircraftReservationSystem.DataAccess.Data;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using AircraftReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.DataAccess.Repository
{
    public class PaymentTypeRepository:Repository<PaymentType>,IPaymentTypeRepository
    {
        private ApplicationDbContext _db;

        public PaymentTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
