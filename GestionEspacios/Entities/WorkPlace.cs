using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WorkPlace 
    {
        public int Id { get; set; }
        public int OfficeId { get; set; }
        public List<Reservation>? Reservations { get; set; }
        public Office? Office { get; set; }
    }
}
