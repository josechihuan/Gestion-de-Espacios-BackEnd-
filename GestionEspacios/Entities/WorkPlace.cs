using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WorkPlace : Office
    {
        public int Id { get; set; }
        public Office OfficeId { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
