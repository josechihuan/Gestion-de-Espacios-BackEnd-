using Microsoft.AspNetCore.Identity;
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

        public int PersonId { get; set; }
        
        public int WorkPlaceId { get; set; }
        
        public DateTime BookingStartDate { get; set; }
        
        public DateTime BookingEndDate { get; set; }
        
        public Person? Person { get; set; }
        
        public WorkPlace? WorkPlace { get; set; }

    }
}
