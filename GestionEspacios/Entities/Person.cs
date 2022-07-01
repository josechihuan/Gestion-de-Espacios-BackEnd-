using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Person
    {
        public int Id { get; set; } 

        public string Company { get; set; }
             
        public string Avatar { get; set; }

        public string UserId { get; set; }
               
        public IdentityUser? User { get; set; }
                 
        public List<Reservation>? Reservations { get; set; } 


    }
}
