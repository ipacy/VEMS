using System;
using System.ComponentModel.DataAnnotations.Schema;
using VEMS.Models.DB.Options;
using VEMS.Models.DB.UserExams;

namespace VEMS.Models.DB.UserAnswers
{
    public class UserAnswer : BaseModel
    {
        [ForeignKey("UserExam")]
        public Guid UserExamId { get; set; }
        public virtual UserExam UserExam { get; set; }


        [ForeignKey("Option")]
        public Guid OptionId { get; set; }
        public virtual Option Option { get; set; }

    }
}
