using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObject.Requests.Question
{
    public class CreateNewQuestionRequest
    {
        public string Text { get; set; }
        public string Type { get; set; }
        public string? Options { get; set; }
        public int SurveyId { get; set; }
    }
}
