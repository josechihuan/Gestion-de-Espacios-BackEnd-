using DataAccess;
using DataAccess.Persons;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionEspacios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IGenericRepository<Person> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonRepository _personRepository;
       

        public PersonsController(IGenericRepository<Person> genericRepository, IUnitOfWork unitOfWork, IPersonRepository personRepository)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            return await _personRepository.GetAll();
        }

        [HttpGet]
        [Route("Id/{id}")]
        public async Task<Person> GetById(int id)
        {
            return (await _personRepository.GetByIdPerson(id)).FirstOrDefault();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Person person)
        {
            var created = await _genericRepository.AddAsync(person);

            if (created) _unitOfWork.Commit();

            return Created("Created", person);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Person person)
        {
            var update = await _genericRepository.UpdateAsync(person);
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
