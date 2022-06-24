﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WorkPlace 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }

        public List<Reservation>? Reservations { get; set; }
       
    }
}
