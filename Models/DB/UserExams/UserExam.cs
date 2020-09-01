using System;
using System.ComponentModel.DataAnnotations.Schema;
using VEMS.Models.DB.Exams;
using VEMS.Models.DB.Exams.enums;
using VEMS.Models.DB.Identity;

namespace VEMS.Models.DB.UserExams
{
    public class UserExam : BaseModel
    {
        [ForeignKey("ApplicationUser")]
        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Exam")]
        public Guid ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public Status Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Score { get; set; }
    }
}
