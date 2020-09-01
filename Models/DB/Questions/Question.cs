using Microsoft.CodeAnalysis.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VEMS.Models.DB.ExamQuestions;
using VEMS.Models.DB.Options;
using VEMS.Models.DB.Questions.enums;

namespace VEMS.Models.DB.Questions
{
    public class Question : BaseModel
    {
        public string Title { get; set; }

        public AnswerType Type { get; set; }

        public int RatePolicy { get; set; }

        public virtual ICollection<Option> Options { get; set; }

        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
    }
}
