using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VEMS.Models.Auth
{
    public class Register
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Please provide valid email address...")]
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
