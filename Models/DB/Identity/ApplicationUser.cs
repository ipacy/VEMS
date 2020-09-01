using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VEMS.Models.DB.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }

        //public virtual ICollection<ApplicationUserExam> ApplicationUserExams { get; set; }
    }
}
