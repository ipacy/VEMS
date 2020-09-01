using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.Models;
using VEMS.Models.DB.UserExams;
using VEMS.Models.DB.UserExams.ViewModels;

namespace VEMS.Services.V1
{
    public interface IUserExamService
    {
        Task<ApiResponse<List<UserExam>>> Get();
        Task<ApiResponse<UserExamViewModel>> GetUserExamById(Guid id, Guid examId);
        Task<ApiResponse<bool>> DeleteUserExam(Guid id, Guid examId);
        Task<ApiResponse<bool>> EnrollUserExam(UserExamViewModel userexam);
        Task<ApiResponse<bool>> UpdateUserExamStatus(Guid userExamId);
    }
}

//Task<bool> Put(UserExam userexam);