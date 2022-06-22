using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkPlaceId { get; set; }
        public int MeetingId { get; set; }

        public User User { get; set; }
        public WorkPlace WorkPlace { get; set; }
        public Meeting Meeting { get; set; }

    }
}
