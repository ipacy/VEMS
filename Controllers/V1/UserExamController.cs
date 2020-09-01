using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VEMS.Models.DB.Identity;
using VEMS.Models.DB.UserExams;
using VEMS.Models.DB.UserExams.ViewModels;
using VEMS.Services.V1;

namespace VEMS.Controllers.V1
{
    public class UserExamController : BaseController
    {
        private readonly IUserExamService userExamService;
        public UserExamController(IUserExamService userExamService)
        {
            this.userExamService = userExamService;

        }

        [HttpGet("GetExamByUser")]
        public async Task<IActionResult> GetExamByUser()
        {
            return Ok(await userExamService.Get());
        }

        [HttpGet("GetUserExamById")]
        public async Task<IActionResult> GetUserExamById(Guid id, Guid examId)
        {
            return Ok(await userExamService.GetUserExamById(id, examId));
        }

        [HttpPost("EnrollUserExam")]
        public async Task<IActionResult> EnrollUserExam(UserExamViewModel userExam)
        {
            return Ok(await userExamService.EnrollUserExam(userExam));
        }

        [HttpPut("UpdateUserExamStatus")]
        public async Task<IActionResult> UpdateUserExamStatus(Guid userExamId)
        {
            return Ok(await userExamService.UpdateUserExamStatus(userExamId));
        }

        [HttpDelete("DeleteUserExam")]
        public async Task<IActionResult> DeleteUserExam(Guid id, Guid examId)
        {
            return Ok(await userExamService.DeleteUserExam(id, examId));
        }
    }
}


/*[HttpPut]
public async Task<IActionResult> Put(UserExam exam)
{
    return Ok(await userExamService.Put(exam));
}*/
