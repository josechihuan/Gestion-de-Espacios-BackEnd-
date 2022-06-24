using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionEspacios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IGenericRepository<Reservation> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
     

        public ReservationsController(IGenericRepository<Reservation> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
          
        }

        [HttpGet]
        public async Task<IEnumerable<Reservation>> Get()
        {
            return await _genericRepository.GetAllAsync();
        }



        [HttpPost]//crear

        public async Task<IActionResult> Create([FromBody] Reservation reservation)

        {
            var created = await _genericRepository.AddAsync(reservation);
            if (created) _unitOfWork.Commit();
            return Created("Created", reservation);
        }
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

