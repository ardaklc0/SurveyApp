using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Entities
{
    public class Response : IEntity
    {
        public int Id { get; set; }
        public string Answers { get; set; }
        public DateTime AnswerDate { get; set; }
        public Survey Survey { get; set; }
        public int SurveyId { get; set; }
    }
}
