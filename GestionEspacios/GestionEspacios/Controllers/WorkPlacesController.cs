using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionEspacios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkPlacesController : ControllerBase
    {

        private readonly IGenericRepository<WorkPlace> _genericRepository;

        private readonly IUnitOfWork _unitOfWork;

        public WorkPlacesController(IGenericRepository<WorkPlace> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<WorkPlace>> Get()
        {
            return await _genericRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WorkPlace workPlace)
        {
            var created = await _genericRepository.AddAsync(workPlace);

            if (created) _unitOfWork.Commit();

            return Created("created", workPlace);

        }

    }
}

