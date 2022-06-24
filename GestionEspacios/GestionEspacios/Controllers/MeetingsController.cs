using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionEspacios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly IGenericRepository<Meeting> _genericRepository;

        private readonly IUnitOfWork _unitOfWork;

        public MeetingsController(IGenericRepository<Meeting> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Meeting meeting)
        {
            var created = await _genericRepository.AddAsync(meeting);

            if (created) _unitOfWork.Commit();

            return Created("created", meeting);

        }
    }
}
