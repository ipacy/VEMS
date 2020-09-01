using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.Models.DB.ExamQuestions;

namespace VEMS.Data.Extensions
{
    public static class BuilderConfiguration
    {
        public static void ApplyBuilderConfiguration(this ModelBuilder modelBuilder)
        {
            //------------------Exam & Questions --------------------------//

            modelBuilder.Entity<ExamQuestion>()
                 .HasKey(eq => new { eq.ExamId, eq.QuestionId });

            modelBuilder.Entity<ExamQuestion>()
               .HasOne(ex => ex.Exam)
               .WithMany(eq => eq.ExamQuestions)
               .HasForeignKey(ex => ex.ExamId);

            modelBuilder.Entity<ExamQuestion>()
                .HasOne(qu => qu.Question)
                .WithMany(eq => eq.ExamQuestions)
                .HasForeignKey(qu => qu.QuestionId);
        }
    }
}
