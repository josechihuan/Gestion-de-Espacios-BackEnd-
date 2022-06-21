using Entities;
using Entities.Entity_F;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public UsersRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await (from user in _dataBaseContext.Users
                          join role in _dataBaseContext.Roles on user.RoleId equals role.Id
                          
                          select new User
                          {

                          }
                          ).ToListAsync();
              
                
        }


    }
}
