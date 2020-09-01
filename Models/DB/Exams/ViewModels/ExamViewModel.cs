using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.Models.DB.Exams.enums;

namespace VEMS.Models.DB.Exams.ViewModels
{
    public class ExamViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
