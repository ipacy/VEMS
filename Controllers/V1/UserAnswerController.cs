using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VEMS.Models.DB.Questions.enums;
using VEMS.Models.DB.UserAnswers;
using VEMS.Models.DB.UserAnswers.ViewModels;
using VEMS.Services.V1;

namespace VEMS.Controllers.V1
{
    public class UserAnswerController : BaseController
    {
        private readonly IUserAnswerService userAnswerService;
        public UserAnswerController(IUserAnswerService userAnswerService)
        {
            this.userAnswerService = userAnswerService;
        }

        [HttpPost("SubmitUserAnswer")]
        public async Task<IActionResult> SubmitUserAnswer(List<UserAnswerViewModel> userAnswer)
        {
            return Ok(await userAnswerService.SubmitUserAnswer(userAnswer));
        }
    }
}



/*[HttpGet]
public async Task<IActionResult> Get()
{
    return Ok(await userAnswerService.Get());
}*/