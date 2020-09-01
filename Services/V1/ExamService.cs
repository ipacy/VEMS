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
using VEMS.Models.DB.Exams.ViewModels;

namespace VEMS.Services.V1
{
    public class ExamService : IExamService
    {
        private readonly ApplicationDbContext dbContext;

        public ExamService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ApiResponse<bool>> AddExam(ExamViewModel exam)
        {
            var result = new ApiResponse<bool>();
            try
            {
                var oExam = new Exam
                {
                    Title = exam.Title,
                    Description = exam.Description,
                    Duration = exam.Duration,
                    ImageUrl = exam.ImageUrl,
                    Status = exam.Status,
                };
                await dbContext.Exams.AddAsync(oExam);
                await dbContext.SaveChangesAsync();
                result.Data = true;
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
                result.Data = false;
                return await Task.FromResult(result);
            }
        }

        public async Task<ApiResponse<List<ExamViewModel>>> Get()
        {
            var result = new ApiResponse<List<ExamViewModel>>();
            try
            {
                result.Data = await dbContext.Exams
                    .Select(e => new ExamViewModel
                    {
                        Id = e.Id,
                        Title = e.Title,
                        Description = e.Description,
                        Duration = e.Duration,
                        ImageUrl = e.ImageUrl,
                        Status = e.Status,
                        CreatedDate = e.CreatedDate
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

        public async Task<ApiResponse<bool>> UdpateExam(ExamViewModel exam)
        {
            var result = new ApiResponse<bool>();
            try
            {
                var oExam = new Exam
                {
                    Id = exam.Id,
                    Title = exam.Title,
                    Status = exam.Status,
                    Description = exam.Description,
                    Duration = exam.Duration,
                    ImageUrl = exam.ImageUrl
                };
                dbContext.Exams.Update(oExam);
                await dbContext.SaveChangesAsync();
                result.Data = true;
                result.AddSuccess();
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
