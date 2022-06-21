﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Meeting
    {
        public int Id { get; set; }
        public DateTime ReservationTime { get; set; }
        public List<Reservation> Reservations { get; set; }

    }
}