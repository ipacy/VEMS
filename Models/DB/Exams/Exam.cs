using System.Collections.Generic;
using VEMS.Models.DB.ExamQuestions;
using VEMS.Models.DB.Exams.enums;

namespace VEMS.Models.DB.Exams
{
    public class Exam : BaseModel
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
    }
}
