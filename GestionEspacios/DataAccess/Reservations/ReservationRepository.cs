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
                          join workPlace in _dataBaseContext.WorkPlaces on reservation.SpaceId equals workPlace.Id
                          select new Reservation
                          {
                              Id = reservation.Id,
                              SpaceId = reservation.SpaceId,
                              Date = reservation.Date,                            
                              PersonId = reservation.PersonId,
                              Person = person,
                              WorkPlace = workPlace,
    
                          }).ToListAsync();
        }

        public async Task<Reservation> Create(Reservation reservation)
        {

           
            var department = _dataBaseContext.WorkPlaces;
            var personCompany = _dataBaseContext.Persons;

            var filterBitwork = department.Where(x => x.Company.Equals("bitwok"));
            var filterMarketing = department.Where(x => x.Company.Equals("marketing"));
            var personBitwork = personCompany.Where(x => x.Company.Equals("bitwok"));
            var personMarketing = personCompany.Where(x => x.Company.Equals("marketing"));
            var booking = reservation.Date; 
            var now = ((TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time"))));


            if (personBitwork == filterBitwork || personMarketing == filterMarketing )
            {

                if (now.DayOfWeek == DayOfWeek.Friday)
                {
                    booking = new DateTime(now.Year, now.Month, now.Day + 4);

                }               
                else
                {
                    booking = new DateTime(now.Year, now.Month, now.Day + 2);

                }
              
            }
            else
            {
                if (now.DayOfWeek == DayOfWeek.Friday)
                {
                    booking = new DateTime(now.Year, now.Month, now.Day + 3);

                }                
                else
                {
                    booking = new DateTime(now.Year, now.Month, now.Day + 1);

                }
              

            }

            _dataBaseContext.Add(reservation);
            await _dataBaseContext.SaveChangesAsync();
            return reservation;


            //    var startDate = reservation.BookingStartDate;
            //    var nextMonday = reservation.BookingStartDate;
            //    var endDate = reservation.BookingEndDate;
            //    var department = newReserve.WorkPlace.Company;
            //    var now = DateTime.Now;

            //    if (department == "bitwork" && department == "marketing")
            //    {

            //        if (now.DayOfWeek == DayOfWeek.Friday)
            //        {
            //            var nextWeek = (DateTime.Now).AddDays(7);
            //            nextMonday = new GregorianCalendar().AddDays(nextWeek, -((int)nextWeek.DayOfWeek) + 2);

            //            nextMonday = new DateTime(now.Year, now.Month, now.Day + 2, 00, 00, 0, DateTimeKind.Utc);
            //            endDate = new DateTime(now.Year, now.Month, now.Day + 2, 23, 59, 59, DateTimeKind.Utc);


            //        }
            //        else if (now.DayOfWeek == DayOfWeek.Saturday)
            //        {
            //            var nextWeek = (DateTime.Now).AddDays(7);
            //            nextMonday = new GregorianCalendar().AddDays(nextWeek, -((int)nextWeek.DayOfWeek) + 1);

            //            nextMonday = new DateTime(now.Year, now.Month, now.Day + 2, 00, 00, 0, DateTimeKind.Utc);
            //            endDate = new DateTime(now.Year, now.Month, now.Day + 2, 23, 59, 59, DateTimeKind.Utc);
            //        }

            //        else
            //        {
            //            startDate = new DateTime(now.Year, now.Month, now.Day + 2, 00, 00, 0, DateTimeKind.Utc);
            //            endDate = new DateTime(now.Year, now.Month, now.Day + 2, 23, 59, 59, DateTimeKind.Utc);

            //        }
            //            _dataBaseContext.Reservations.Add(reservation);
            //            await _dataBaseContext.SaveChangesAsync();

            //        }
            //        else
            //        {


            //            if (now.DayOfWeek == DayOfWeek.Friday)
            //            {
            //                var nextWeek = (DateTime.Now).AddDays(7);
            //                nextMonday = new GregorianCalendar().AddDays(nextWeek, -((int)nextWeek.DayOfWeek) + 1);

            //                nextMonday = new DateTime(now.Year, now.Month, now.Day + 1, 00, 00, 0, DateTimeKind.Utc);
            //                endDate = new DateTime(now.Year, now.Month, now.Day + 1, 23, 59, 59, DateTimeKind.Utc);

            //            }
            //            else if (now.DayOfWeek == DayOfWeek.Saturday)
            //            {
            //                var nextWeek = (DateTime.Now).AddDays(6);
            //                nextMonday = new GregorianCalendar().AddDays(nextWeek, -((int)nextWeek.DayOfWeek) + 1);

            //                nextMonday = new DateTime(now.Year, now.Month, now.Day + 1, 00, 00, 0, DateTimeKind.Utc);
            //                endDate = new DateTime(now.Year, now.Month, now.Day + 1, 23, 59, 59, DateTimeKind.Utc);
            //            }
            //            else
            //            {
            //                startDate = new DateTime(now.Year, now.Month, now.Day + 1, 00, 00, 0, DateTimeKind.Utc);
            //                endDate = new DateTime(now.Year, now.Month, now.Day + 1, 23, 59, 59, DateTimeKind.Utc);

            //            }
            //            _dataBaseContext.Reservations.Add(reservation);
            //            await _dataBaseContext.SaveChangesAsync();

            //        }
            //        return reservation;

        }
    }
}
