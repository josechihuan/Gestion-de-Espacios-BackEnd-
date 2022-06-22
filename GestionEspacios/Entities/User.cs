using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public int RoleId { get; set; }
        public int DepartmentId { get; set; }
        public List<ResetPasswordAttemp> ResetPasswordAttemps { get; set; }

        public Role Role { get; set; }
        public Department Department { get; set; }
    }
}
