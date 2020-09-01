using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VEMS.Models.DB.DTO
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
        public Guid Id { get; set; }
    }
}
