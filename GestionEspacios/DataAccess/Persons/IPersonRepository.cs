using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persons
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAll();

        Task<IEnumerable<Person>> GetByIdPerson(int id);
    
    }
}
