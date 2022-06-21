using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Office
    {
        public int Id { get; set; }
        public List<WorkPlace> WorkPlaces { get; set; }
        public DateTime BookingDate { get; set; }


    }
}
