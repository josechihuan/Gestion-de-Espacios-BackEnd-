using DataAccess;
using DataAccess.WorkPlaces;
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
        private readonly IWorkPlaceRepository _workPlaceRepository;

        public WorkPlacesController(IGenericRepository<WorkPlace> genericRepository, IUnitOfWork unitOfWork, IWorkPlaceRepository workPlaceRepository)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _workPlaceRepository = workPlaceRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<WorkPlace>> Get()
        {
            return await _workPlaceRepository.GetAll();
        }

    }
}
