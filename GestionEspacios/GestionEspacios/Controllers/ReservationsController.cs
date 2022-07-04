using DataAccess;
using DataAccess.Reservations;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace GestionEspacios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IGenericRepository<Reservation> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReservationRepository _reservationRepository;


        public ReservationsController(IGenericRepository<Reservation> genericRepository, IUnitOfWork unitOfWork, IReservationRepository reservationRepository)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _reservationRepository = reservationRepository;
        }

        
        [HttpGet]
        public async Task<IEnumerable<Reservation>> Get()
        {
            return await _reservationRepository.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Reservation reservation)
        {
            try
            {
                var newReserved = await _reservationRepository.Create(reservation);
                return CreatedAtAction(nameof(Get), new { id = newReserved.Id }, newReserved);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }
    



        //[HttpPost]//crear
        //public async Task<IActionResult> Create([FromBody] Reservation reservation)

        //{
        //    var department = reservation.WorkPlaceId;

        //    if (department > 1  &&  department >= 3)
        //    {
        //        var now = DateTime.Now;
        //        var fromDate = new DateTime(now.Year, now.Month, now.Day + 2, 00, 00, 0, DateTimeKind.Utc);
        //        var toDate = new DateTime(now.Year, now.Month, now.Day + 2, 23, 59, 59, DateTimeKind.Utc);

        //        if (now.DayOfWeek == DayOfWeek.Friday)
        //        {
        //            var nextWeek = (DateTime.Now).AddDays(7);
        //            var nextMonday = new GregorianCalendar().AddDays(nextWeek, -((int)nextWeek.DayOfWeek) + 2);
        //        }
        //        var created = await _genericRepository.AddAsync(reservation);
        //        if (created) _unitOfWork.Commit();

        //    }
        //    else
        //    {
        //        var now = DateTime.Now;
        //        var fromDate = new DateTime(now.Year, now.Month, now.Day + 1, 00, 00, 0, DateTimeKind.Utc);
        //        var toDate = new DateTime(now.Year, now.Month, now.Day + 1, 23, 59, 59, DateTimeKind.Utc);

        //        if (now.DayOfWeek == DayOfWeek.Friday)
        //        {
        //            var nextWeek = (DateTime.Now).AddDays(7);
        //            var nextMonday = new GregorianCalendar().AddDays(nextWeek, -((int)nextWeek.DayOfWeek) + 1);
        //        }
        //        var created = await _genericRepository.AddAsync(reservation);
        //        if (created) _unitOfWork.Commit();

        //    }
        //    return Created("Created", reservation);

        //}

        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Reservation reservation)
        {
           
            var update = await _genericRepository.UpdateAsync(reservation);
            if (update) _unitOfWork.Commit();
            return Ok(update);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _genericRepository.DeleteAsync(x => x.Id == id);
            if (deleted) _unitOfWork.Commit();
            return Ok(deleted);

        }

    }
}

