using Entities;
using Entities.Entity_F;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Reservations
{
    public class ReservationRepository : IReservationRepository
    {

        private readonly DataBaseContext _dataBaseContext;


        public ReservationRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;

        }



        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await (from person in _dataBaseContext.Persons
                          join reservation in _dataBaseContext.Reservations on person.Id equals reservation.PersonId
                          join workPlace in _dataBaseContext.WorkPlaces on reservation.WorkPlaceId equals workPlace.Id
                          select new Reservation
                          {
                              Id = reservation.Id,
                              WorkPlaceId = reservation.WorkPlaceId,
                              BookingEndDate = reservation.BookingEndDate,
                              BookingStartDate = reservation.BookingStartDate,
                              PersonId = reservation.PersonId,
                              Person = person,
                              WorkPlace = workPlace,

                          }).ToListAsync();
        }

        public async Task<Reservation> Create(Reservation reservation)
        {


            var startDate = reservation.BookingStartDate;
            var nextMonday = reservation.BookingStartDate;
            var endDate = reservation.BookingEndDate;
            var department = reservation.WorkPlaceId;
            var now = DateTime.Now;

            if (department > 1 && department >= 3)
            {



                if (now.DayOfWeek == DayOfWeek.Friday)
                {
                    var nextWeek = (DateTime.Now).AddDays(7);
                    nextMonday = new GregorianCalendar().AddDays(nextWeek, -((int)nextWeek.DayOfWeek) + 2);

                    nextMonday = new DateTime(now.Year, now.Month, now.Day + 2, 00, 00, 0, DateTimeKind.Utc);
                    endDate = new DateTime(now.Year, now.Month, now.Day + 2, 23, 59, 59, DateTimeKind.Utc);


                }
                else if (now.DayOfWeek == DayOfWeek.Saturday)
                {
                    var nextWeek = (DateTime.Now).AddDays(7);
                    nextMonday = new GregorianCalendar().AddDays(nextWeek, -((int)nextWeek.DayOfWeek) + 1);

                    nextMonday = new DateTime(now.Year, now.Month, now.Day + 2, 00, 00, 0, DateTimeKind.Utc);
                    endDate = new DateTime(now.Year, now.Month, now.Day + 2, 23, 59, 59, DateTimeKind.Utc);
                }

                else
                {
                    startDate = new DateTime(now.Year, now.Month, now.Day + 2, 00, 00, 0, DateTimeKind.Utc);
                    endDate = new DateTime(now.Year, now.Month, now.Day + 2, 23, 59, 59, DateTimeKind.Utc);

                }
                    _dataBaseContext.Reservations.Add(reservation);
                    await _dataBaseContext.SaveChangesAsync();

                }
                else
                {


                    if (now.DayOfWeek == DayOfWeek.Friday)
                    {
                        var nextWeek = (DateTime.Now).AddDays(7);
                        nextMonday = new GregorianCalendar().AddDays(nextWeek, -((int)nextWeek.DayOfWeek) + 1);

                        nextMonday = new DateTime(now.Year, now.Month, now.Day + 1, 00, 00, 0, DateTimeKind.Utc);
                        endDate = new DateTime(now.Year, now.Month, now.Day + 1, 23, 59, 59, DateTimeKind.Utc);

                    }
                    else if (now.DayOfWeek == DayOfWeek.Saturday)
                    {
                        var nextWeek = (DateTime.Now).AddDays(6);
                        nextMonday = new GregorianCalendar().AddDays(nextWeek, -((int)nextWeek.DayOfWeek) + 1);

                        nextMonday = new DateTime(now.Year, now.Month, now.Day + 1, 00, 00, 0, DateTimeKind.Utc);
                        endDate = new DateTime(now.Year, now.Month, now.Day + 1, 23, 59, 59, DateTimeKind.Utc);
                    }
                    else
                    {
                        startDate = new DateTime(now.Year, now.Month, now.Day + 1, 00, 00, 0, DateTimeKind.Utc);
                        endDate = new DateTime(now.Year, now.Month, now.Day + 1, 23, 59, 59, DateTimeKind.Utc);

                    }
                    _dataBaseContext.Reservations.Add(reservation);
                    await _dataBaseContext.SaveChangesAsync();

                }
                return reservation;
            
        }
    }
}
