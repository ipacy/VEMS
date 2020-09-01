using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VEMS.Data.Extensions;
using VEMS.Models.DB;
using VEMS.Models.DB.ExamQuestions;
using VEMS.Models.DB.Exams;
using VEMS.Models.DB.Identity;
using VEMS.Models.DB.Options;
using VEMS.Models.DB.Questions;
using VEMS.Models.DB.UserAnswers;
using VEMS.Models.DB.UserExams;

namespace VEMS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
                ApplicationRole, Guid, ApplicationUserClaim, ApplicationUserRole,
                IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyIdentityTableConfiguration();
            modelBuilder.ApplyBuilderConfiguration();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = this.ChangeTracker
               .Entries()
               .Where(e => e.State == EntityState.Added
            );

            foreach (var entityEntry in entries)
            {
                if (entityEntry.Entity is BaseModel)
                {
                    (entityEntry.Entity as BaseModel).Id = Guid.NewGuid();
                    (entityEntry.Entity as BaseModel).CreatedDate = DateTime.Now;
                }

            }
            return (await base.SaveChangesAsync(true, cancellationToken));
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<UserExam> UserExams { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }


    }
}