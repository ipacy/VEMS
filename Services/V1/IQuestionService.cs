using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.Models;
using VEMS.Models.DB.ExamQuestions;
using VEMS.Models.DB.ExamQuestions.ViewModels;
using VEMS.Models.DB.Options;
using VEMS.Models.DB.Questions;
using VEMS.Models.DB.Questions.ViewModels;

namespace VEMS.Services.V1
{
    public interface IQuestionService
    {
        Task<ApiResponse<List<QuestionViewModel>>> Get();
        Task<ApiResponse<List<ExamQuestionViewModel>>> GetQuestionsByExam(Guid examId);
        Task<ApiResponse<List<Option>>> GetOptionsByQuestion(Guid questionId, Guid userExamId);
        Task<ApiResponse<Question>> GetQuestionsById(Guid examId);
        Task<bool> Put(QuestionViewModel question);
        Task<ApiResponse<bool>> Delete(Guid id);
        Task<bool> AddQuestion(QuestionViewModel question, Guid examId);
    }
}
