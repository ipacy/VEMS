using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VEMS.Models.DB
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
