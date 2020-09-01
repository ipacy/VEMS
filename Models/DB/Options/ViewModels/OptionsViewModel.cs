using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VEMS.Models.DB.Options.ViewModels
{
    public class OptionsViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Score { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }
    }
}
