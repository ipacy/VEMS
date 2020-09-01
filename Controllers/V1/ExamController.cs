using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VEMS.Models.DB.DTO;
using VEMS.Models.DB.Exams;
using VEMS.Models.DB.Exams.ViewModels;
using VEMS.Services.V1;

namespace VEMS.Controllers.V1
{
    //[Authorize]
    public class ExamController : BaseController
    {
        private readonly IExamService examService;
        public ExamController(IExamService examService)
        {
            this.examService = examService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await examService.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Post(ExamViewModel exam)
        {
            return Ok(await examService.AddExam(exam));
        }

        [HttpPut]
        public async Task<IActionResult> Put(ExamViewModel exam)
        {
            return Ok(await examService.UdpateExam(exam));
        }
    }
}
