using VEMS.Data;
using VEMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.Models.DB.DTO;
using VEMS.Models.DB.Exams;
using VEMS.Models.DB.Questions;
using VEMS.Models.DB.Options;
using VEMS.Models.DB.ExamQuestions;
using VEMS.Models.DB.Questions.ViewModels;
using VEMS.Models.DB.Options.ViewModels;
using VEMS.Models.DB.ExamQuestions.ViewModels;

namespace VEMS.Services.V1
{
    public class QuestionService : IQuestionService
    {

        private readonly ApplicationDbContext dbContext;

        public QuestionService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddQuestion(QuestionViewModel question, Guid examId)
        {
            try
            {
                var oQuestion = new Question
                {
                    Title = question.Title,
                    RatePolicy = question.RatePolicy,
                    Options = (ICollection<Option>)question.Options,
                    Type = question.Type
                };
                await dbContext.Questions.AddAsync(oQuestion);
                await dbContext.SaveChangesAsync();

                var examQuestion = new ExamQuestion
                {
                    ExamId = examId,
                    QuestionId = oQuestion.Id
                };

                await dbContext.ExamQuestions.AddAsync(examQuestion);
                await dbContext.SaveChangesAsync();

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<ApiResponse<bool>> Delete(Guid id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var question = await dbContext.Questions.FindAsync(id);

                var options = await dbContext.Options.Where(q => q.QuestionId == id).ToListAsync();

                foreach (var i in options)
                {
                    dbContext.Options.Remove(i);
                }
                await dbContext.SaveChangesAsync();


                if (question == null)
                {
                    response.Data = false;
                    response.AddMessage("Questions not found");
                    return await Task.FromResult(response);
                }

                dbContext.Questions.Remove(question);
                await dbContext.SaveChangesAsync();



                response.Data = true;
                response.AddSuccess();
                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                response.AddError(ex);
                return await Task.FromResult(response);
            }
        }

        public async Task<ApiResponse<List<QuestionViewModel>>> Get()
        {
            var result = new ApiResponse<List<QuestionViewModel>>();
            try
            {
                result.Data = await dbContext.Questions
                    .Include(a => a.Options)
                    .Select(q => new QuestionViewModel
                    {
                        Id = q.Id,
                        Title = q.Title,
                        Type = q.Type,
                        Options = q.Options,
                        RatePolicy = q.RatePolicy
                    })
                    .ToListAsync();


                result.AddSuccess();
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {

                result.AddError(ex);
                return await Task.FromResult(result);
            }
        }

        public async Task<ApiResponse<List<ExamQuestionViewModel>>> GetQuestionsByExam(Guid examId)
        {
            var result = new ApiResponse<List<ExamQuestionViewModel>>();
            try
            {
                var oList = await dbContext.ExamQuestions
                            .Where(ex => ex.ExamId == examId)
                            .Include(e => e.Question)
                            .Include(e => e.Exam)
                            .Select(e => new ExamQuestionViewModel
                            {
                                ExamId = e.ExamId,
                                QuestionId = e.QuestionId,
                                Exam = e.Exam.Title,
                                Question = e.Question.Title,
                                Type = e.Question.Type,
                                RatePolicy = e.Question.RatePolicy
                            })
                            .ToListAsync();

                result.Data = oList;
                result.AddSuccess();
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {

                result.AddError(ex);
                return await Task.FromResult(result);
            }
        }

        public async Task<ApiResponse<Question>> GetQuestionsById(Guid examId)
        {
            var result = new ApiResponse<Question>();
            try
            {
                var response = await dbContext.Questions
                   .Include(e => e.Options).ToListAsync();
                var oList = response.SingleOrDefault(e => e.Id == examId);
                result.Data = oList;
                result.AddSuccess();
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
                return await Task.FromResult(result);
            }

        }

        public async Task<bool> Put(QuestionViewModel questionView)
        {
            try
            {
                var question = new Question
                {
                    Id = questionView.Id,
                    Type = questionView.Type,
                    Title = questionView.Title,
                    RatePolicy = questionView.RatePolicy
                };
                dbContext.Questions.Update(question);
                await dbContext.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<ApiResponse<List<Option>>> GetOptionsByQuestion(Guid questionId, Guid userExamId)
        {

            var result = new ApiResponse<List<Option>>();
            try
            {
                var response = dbContext.Options.
                    Where(o => o.Question.Id == questionId).ToList()
                    .Select(e => { e.IsCorrect = false; return e; }).ToList();

                var optionSelected = dbContext.UserAnswers
                    .Where(e => (e.Option.QuestionId == questionId && e.UserExamId == userExamId));

                if (optionSelected.Count() == 0)
                {
                    result.Data = response;
                    result.AddSuccess();
                }
                else
                {
                    result.Data = null;
                    result.AddMessage("Question answered already");
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
