using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.WorkPlaces
{
    public interface IWorkPlaceRepository
    {
        Task<IEnumerable<WorkPlace>> GetAll();
    }
}
