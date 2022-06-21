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
        public User UserId { get; set; }
        public WorkPlace WorkPlaceId { get; set; }
        public Meeting MeetingId { get; set; }

    }
}
