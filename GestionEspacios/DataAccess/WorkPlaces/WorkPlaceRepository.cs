using Entities;
using Entities.Entity_F;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.WorkPlaces
{
    public class WorkPlaceRepository : IWorkPlaceRepository
    {

        private readonly DataBaseContext _dataBaseContext;
        

        public WorkPlaceRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
           
        }

        public async Task<IEnumerable<WorkPlace>> GetAll()
        {
            return await (from workPlace in _dataBaseContext.WorkPlaces
                          join reservation in _dataBaseContext.Reservations on workPlace.Id equals reservation.SpaceId
                          select new WorkPlace
                          {
                              Id = workPlace.Id,
                              Name = workPlace.Name,
                              Company = workPlace.Company,
                              Ocupation = workPlace.Ocupation

                          }).ToListAsync();
        }
    }
}
