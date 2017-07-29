using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Models.Auth
{
    public class RegisterRequest
    {
        [Required]
        public String Username { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }
    }
}
