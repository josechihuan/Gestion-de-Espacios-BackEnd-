using Entities.Entity_F;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Database.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new DataBaseContext(serviceProvider.GetRequiredService<DbContextOptions<DataBaseContext>>()))
            {

                if (_context.WorkPlaces.Any())
                {
                    return;
                }
                _context.WorkPlaces.AddRange(
                    new WorkPlace { Name = "puesto1", Company = "bitwork", Ocupation = false },
                    new WorkPlace { Name = "puesto2", Company = "bravent", Ocupation = false },
                    new WorkPlace { Name = "puesto3", Company = "marketing", Ocupation = false }
                                   );
                _context.SaveChanges();

            }


        }

    }
}
