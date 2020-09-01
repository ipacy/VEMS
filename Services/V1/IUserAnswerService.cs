using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.Models;
using VEMS.Models.DB.Questions.enums;
using VEMS.Models.DB.UserAnswers;
using VEMS.Models.DB.UserAnswers.ViewModels;

namespace VEMS.Services.V1
{
    public interface IUserAnswerService
    {
        Task<ApiResponse<bool>> SubmitUserAnswer(List<UserAnswerViewModel> userAnswer);
    }
}

/*Task<ApiResponse<List<UserAnswer>>> Get();*/
