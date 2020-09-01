using Microsoft.CodeAnalysis.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.Models.DB.Exams.enums;
using VEMS.Models.DB.Options;
using VEMS.Models.DB.Questions.enums;

namespace VEMS.Models.DB.UserExams.ViewModels
{
    public class UserExamViewModel
    {
        public Guid Id { get; set; }
        public Guid ApplicationUserId { get; set; }
        public Guid ExamId { get; set; }
        public Status Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Score { get; set; }
    }
}
