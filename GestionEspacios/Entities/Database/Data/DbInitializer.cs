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
                    new WorkPlace { Name = "puesto2", Company = "bitwork", Ocupation = false },
                    new WorkPlace { Name = "puesto3", Company = "bitwork", Ocupation = false },
                    new WorkPlace { Name = "puesto4", Company = "bitwork", Ocupation = false },

                    new WorkPlace { Name = "puesto5", Company = "marketing", Ocupation = false },
                    new WorkPlace { Name = "puesto6", Company = "marketing", Ocupation = false },
                    new WorkPlace { Name = "puesto7", Company = "marketing", Ocupation = false },
                    new WorkPlace { Name = "puesto8", Company = "marketing", Ocupation = false },
                    new WorkPlace { Name = "puesto9", Company = "marketing", Ocupation = false },

                    new WorkPlace { Name = "puesto11", Company = "bravent", Ocupation = false },
                    new WorkPlace { Name = "puesto12", Company = "bravent", Ocupation = false },
                    new WorkPlace { Name = "puesto13", Company = "bravent", Ocupation = false },
                    new WorkPlace { Name = "puesto14", Company = "bravent", Ocupation = false },
                    new WorkPlace { Name = "puesto15", Company = "bravent", Ocupation = false },
                    new WorkPlace { Name = "puesto16", Company = "bravent", Ocupation = false },
                    new WorkPlace { Name = "puesto17", Company = "bravent", Ocupation = false },
                    new WorkPlace { Name = "puesto18", Company = "bravent", Ocupation = false },
                    new WorkPlace { Name = "puesto19", Company = "bravent", Ocupation = false },
                    new WorkPlace { Name = "puesto20", Company = "bravent", Ocupation = false },
                    new WorkPlace { Name = "puesto21", Company = "bravent", Ocupation = false },
                    new WorkPlace { Name = "puesto22", Company = "bravent", Ocupation = false },
                    new WorkPlace { Name = "puesto23", Company = "bravent", Ocupation = false },
                    new WorkPlace { Name = "reuniones", Company = "bravent", Ocupation = false }

                                   );
                _context.SaveChanges();

            }


        }
    }
}
