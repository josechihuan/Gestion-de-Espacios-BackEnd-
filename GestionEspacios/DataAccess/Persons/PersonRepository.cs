using Entities;
using Entities.Entity_F;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persons
{
   public class PersonRepository : IPersonRepository
    {
        private readonly DataBaseContext _dataBaseContext;


        public PersonRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;

        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await (from person in _dataBaseContext.Persons
                          join user in _dataBaseContext.Users on person.UserId equals user.Id
                          join reservation in _dataBaseContext.Reservations on person.Id equals reservation.PersonId
                          select new Person
                          {
                              Id = person.Id,
                              Company = person.Company,
                              Avatar = person.Avatar,
                              UserId = user.Id,
                              User= person.User,
                              Reservations= person.Reservations
                              


                          }).ToListAsync();
        
        }

        public async  Task<IEnumerable<Person>> GetByIdPerson(int id)
        {
            return await (from person in _dataBaseContext.Persons
                         join user in _dataBaseContext.Users on person.UserId equals user.Id
                         where person.Id == id  
                         select new Person
                         {
                             Id = person.Id,
                             Company = person.Company,
                             Avatar = person.Avatar,                             
                             User = person.User                           


                         }).ToListAsync();

        }

        
    }
}
