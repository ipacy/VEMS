using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.Models.DB.Questions.enums;

namespace VEMS.Models.DB.ExamQuestions.ViewModels
{
    public class ExamQuestionViewModel
    {
        public Guid QuestionId { get; set; }
        public string Question { get; set; }
        public Guid ExamId { get; set; }
        public string Exam { get; set; }
        public AnswerType Type { get; set; }
        public int RatePolicy { get; set; }
    }
}
