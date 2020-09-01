using Microsoft.Extensions.DependencyInjection;
using VEMS.Models.DB.Exams;
using VEMS.Models.DB.Options;
using VEMS.Models.DB.Questions;
using VEMS.Models.DB.UserAnswers;
using VEMS.Services.V1;

namespace VEMS.Services.Extensions
{
    public static class EntityServiceExtension
    {
        public static void AddEntityConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IExamService, ExamService>();
            services.AddTransient<IBaseEntityService<Option>, OptionService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IUserExamService, UserExamService>();
            services.AddTransient<IUserAnswerService, UserAnswerService>();
            services.AddTransient<IDashboard, DashboardService>();
        }
    }
}
