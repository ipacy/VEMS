using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VEMS.Data;
using VEMS.Models;
using VEMS.Models.DB.Identity;
using VEMS.Models.DB.Questions.enums;
using VEMS.Models.DB.UserAnswers;
using VEMS.Models.DB.UserAnswers.ViewModels;

namespace VEMS.Services.V1
{
    public class UserAnswerService : IUserAnswerService
    {
        private readonly ApplicationDbContext dbContext;
        public UserAnswerService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ApiResponse<bool>> SubmitUserAnswer(List<UserAnswerViewModel> userAnswer)
        {
            var result = new ApiResponse<bool>();
            try
            {
                var proceed = false;
                for (var i = 0; i < userAnswer.Count; i++)
                {
                    var currentUseranswer = await dbContext.UserAnswers
                    .FirstOrDefaultAsync(a => (a.OptionId == userAnswer[0].OptionId
                    && a.UserExamId == userAnswer[0].UserExamId));


                    if (currentUseranswer == null)
                    {
                        var checkAnswer = await dbContext.Options.FindAsync(userAnswer[0].OptionId);
                        if (checkAnswer.IsCorrect)
                        {
                            var checkUserExam = await dbContext.UserExams.FirstOrDefaultAsync(ue => ue.Id == userAnswer[0].UserExamId);
                            checkUserExam.Score = checkUserExam.Score + checkAnswer.Score;
                        }

                        var oUserAnswer = new UserAnswer
                        {
                            OptionId = userAnswer[i].OptionId,
                            UserExamId = userAnswer[i].UserExamId
                        };
                        await dbContext.AddAsync(oUserAnswer);
                        result.AddSuccess();
                        result.Data = true;
                        proceed = true;
                    }
                    else
                    {
                        result.Data = false;
                        result.AddMessage("Answer Already Exist");
                    }
                }
                if (proceed)
                {
                    await dbContext.SaveChangesAsync();
                }
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
                return await Task.FromResult(result);
            }
        }
    }
}

/*public async Task<ApiResponse<List<UserAnswer>>> Get()
        {
            var result = new ApiResponse<List<UserAnswer>>();
            try
            {
                result.Data = await dbContext.UserAnswers
                    .Include(ue => ue.UserExam)
                    .Include(o => o.Option)
                    .ToListAsync();

                result.AddSuccess();
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {

                result.AddError(ex);
                return await Task.FromResult(result);
            }
        }*/
