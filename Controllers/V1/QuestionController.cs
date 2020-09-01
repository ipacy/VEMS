using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VEMS.Models.DB.Options;
using VEMS.Models.DB.Questions;
using VEMS.Models.DB.Questions.ViewModels;
using VEMS.Services.V1;

namespace VEMS.Controllers.V1
{
    public class QuestionController : BaseController
    {
        private readonly IQuestionService questionService;
        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await questionService.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Post(QuestionViewModel question, Guid examId)
        {
            return Ok(await questionService.AddQuestion(question, examId));
        }

        [HttpPut]
        public async Task<IActionResult> Put(QuestionViewModel exam)
        {
            return Ok(await questionService.Put(exam));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await questionService.Delete(id));
        }

        [HttpGet("GetQuestionsByExam")]
        public async Task<IActionResult> GetQuestionsByExam(Guid examId)
        {
            return Ok(await questionService.GetQuestionsByExam(examId));
        }


        [HttpGet("GetQuestionsById")]
        public async Task<IActionResult> GetQuestionsById(Guid examId)
        {
            return Ok(await questionService.GetQuestionsById(examId));
        }

        [HttpGet("GetOptionsByQuestion")]
        public async Task<IActionResult> GetOptionsByQuestion(Guid questionId, Guid userExamId)
        {
            return Ok(await questionService.GetOptionsByQuestion(questionId, userExamId));
        }
    }
}
