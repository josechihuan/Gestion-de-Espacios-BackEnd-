using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Auth
{
    public class AplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public byte[] Avatar { get; set; }
    }
}
