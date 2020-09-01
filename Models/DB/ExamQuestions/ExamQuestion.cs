using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.Models.DB.Exams;
using VEMS.Models.DB.Questions;

namespace VEMS.Models.DB.ExamQuestions
{
    public class ExamQuestion
    {
        public Guid QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public Guid ExamId { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
