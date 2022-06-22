using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }

        public Company? Company { get; set; }

        public List<User>? Users { get; set; }   
    }
}
