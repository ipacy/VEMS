using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using VEMS.Models.DB.Questions;

namespace VEMS.Models.DB.Options
{
    public class Option : BaseModel
    {
        public string Title { get; set; }

        [StringLength(300)]
        public string ImageUrl { get; set; }
        public int Score { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
