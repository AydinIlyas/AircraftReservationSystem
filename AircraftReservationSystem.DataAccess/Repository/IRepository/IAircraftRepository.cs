using AircraftReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.DataAccess.Repository.IRepository
{
    public interface IAircraftRepository:IRepository<Aircraft>
    {
        public IQueryable<Aircraft> GetAllWithAirlineAndAircraftType();
    }
}
