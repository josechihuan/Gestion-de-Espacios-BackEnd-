using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionEspacios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGenericRepository<User> _genericRepository;

        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IGenericRepository<User> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _genericRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            var created = await _genericRepository.AddAsync(user);  

            if(created) _unitOfWork.Commit();   

            return Created("created", user);

        }

    }
}
