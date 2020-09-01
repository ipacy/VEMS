using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.Models;
using VEMS.Models.DB.Exams;
using VEMS.Models.DB.Exams.ViewModels;

namespace VEMS.Services.V1
{
    public interface IExamService
    {
        Task<ApiResponse<List<ExamViewModel>>> Get();
        Task<ApiResponse<bool>> AddExam(ExamViewModel exam);
        Task<ApiResponse<bool>> UdpateExam(ExamViewModel exam);
    }
}
