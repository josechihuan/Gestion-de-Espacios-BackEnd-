using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ResetPasswordAttemp
    {
        public Guid Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string? UserId { get; set; }
        public List<IdentityUser>? User { get; set; }

    }
}
