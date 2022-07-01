using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reservations
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAll();

        Task<Reservation> Create(Reservation reservation);


    }
}
