using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VEMS.Models.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool IsAdmin { get; set; }
        public string Message { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
