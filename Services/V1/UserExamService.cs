using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.Data;
using VEMS.Models;
using VEMS.Models.DB.Identity;
using VEMS.Models.DB.UserExams;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using VEMS.Models.DB.UserExams.ViewModels;

namespace VEMS.Services.V1
{
    public class UserExamService : IUserExamService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        public IHttpContextAccessor httpContext;
        public UserExamService(ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
             IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.httpContext = httpContextAccessor;
        }

        public async Task<ApiResponse<bool>> EnrollUserExam(UserExamViewModel userExam)
        {
            var result = new ApiResponse<bool>();
            try
            {
                var oUserExam = await dbContext.UserExams
                    .FirstOrDefaultAsync(e => (e.ExamId == userExam.ExamId && e.ApplicationUserId == this.CurrentUser().Id)) as UserExam;

                if (oUserExam == null)
                {
                    var userExamd = new UserExam
                    {
                        ApplicationUserId = this.CurrentUser().Id,
                        ExamId = userExam.ExamId,
                        Status = userExam.Status,
                        StartDate = userExam.StartDate,
                        EndDate = userExam.EndDate,
                        Score = userExam.Score
                    };
                    await dbContext.UserExams.AddAsync(userExamd);
                    await dbContext.SaveChangesAsync();
                    result.Data = true;
                    result.AddSuccess();
                    result.AddMessage("You are Enrolled Succesfully");
                    return await Task.FromResult(result);
                }
                else
                {
                    result.Data = false;
                    result.AddMessage("You have already been enrolled successfully");
                    return await Task.FromResult(result);
                }
            }
            catch (Exception ex)
            {
                result.AddError(ex);
                return await Task.FromResult(result);
            }
        }

        public async Task<ApiResponse<bool>> DeleteUserExam(Guid id, Guid examId)
        {
            var result = new ApiResponse<bool>();
            try
            {
                var entity = await dbContext.UserExams.FirstOrDefaultAsync(a => (a.Id == id && a.ExamId == examId && a.ApplicationUserId == this.CurrentUser().Id));

                dbContext.UserExams.Remove(entity);
                await dbContext.SaveChangesAsync();
                result.Data = true;
                result.AddSuccess();
                result.AddMessage("You left the exam..");
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
                return await Task.FromResult(result);
            }
        }

        public async Task<ApiResponse<UserExamViewModel>> GetUserExamById(Guid id, Guid examId)
        {
            var result = new ApiResponse<UserExamViewModel>();
            try
            {
                var entity = await dbContext.UserExams
                    .Select(u => new UserExamViewModel
                    {
                        ExamId = u.ExamId,
                        ApplicationUserId = u.ApplicationUserId,
                        EndDate = u.EndDate,
                        StartDate = u.StartDate,
                        Score = u.Score,
                        Status = u.Status,
                        Id = u.Id
                    })
                    .FirstOrDefaultAsync(a => (a.Id == id && a.ExamId == examId && a.ApplicationUserId == this.CurrentUser().Id));

                if (entity != null)
                {
                    result.Data = entity;
                    result.AddSuccess();
                    return await Task.FromResult(result);
                }
                else
                {
                    result.Data = entity;
                    result.AddMessage("No Exam Available");
                    return await Task.FromResult(result);
                }

            }
            catch (Exception ex)
            {
                result.AddError(ex);
                return await Task.FromResult(result);
            }


        }

        public async Task<ApiResponse<List<UserExam>>> Get()
        {
            var result = new ApiResponse<List<UserExam>>();
            try
            {
                result.Data = await dbContext.UserExams
                    .Include(ue => ue.Exam)
                    .Include(u => u.ApplicationUser).Where(u => u.ApplicationUserId == this.CurrentUser().Id)
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


        private ApplicationUser CurrentUser()
        {
            try
            {
                var currentUser = this.httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var userFound = this.userManager.Users.SingleOrDefault(c => c.Email == currentUser);

                if (userFound != null)
                {
                    return userFound;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }

        }

        public async Task<ApiResponse<bool>> UpdateUserExamStatus(Guid userExamId)
        {
            var result = new ApiResponse<bool>();
            try
            {
                var userExam = await dbContext.UserExams.FirstOrDefaultAsync(e => e.Id == userExamId);

                if (userExam != null)
                {
                    userExam.Status = Models.DB.Exams.enums.Status.Completed;
                    await dbContext.SaveChangesAsync();
                    result.Data = true;
                    result.AddSuccess();
                }
                else
                {
                    result.Data = false;
                    result.AddMessage("Exam not enrolled yet");
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


/*        public async Task<bool> Put(UserExam userexam)
        {
            try
            {
                dbContext.UserExams.Update(userexam);
                await dbContext.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }*/
