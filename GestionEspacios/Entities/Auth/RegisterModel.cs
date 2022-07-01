using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Auth
{
    public class RegisterModel
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "Name is required")]
        public string? Username { get; set; }

       /* [Required(ErrorMessage = "Name is required")]
        public string? Surname { get; set; }*/

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? RepeatPassword { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

      

    }
}
