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
        public Role? RoleId { get; set; }
        public Department? DepartmentId { get; set; }



    }
}
