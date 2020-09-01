using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.Models.DB.Options;
using VEMS.Models.DB.Questions.enums;

namespace VEMS.Models.DB.Questions.ViewModels
{
    public class QuestionViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public AnswerType Type { get; set; }
        public int RatePolicy { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
