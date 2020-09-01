using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VEMS.Models.DB.UserAnswers.ViewModels
{
    public class UserAnswerViewModel
    {
        public Guid UserExamId { get; set; }
        public Guid OptionId { get; set; }
    }
}
