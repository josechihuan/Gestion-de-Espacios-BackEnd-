using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Users
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAll();
    }
}
