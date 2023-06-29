using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObject.Requests.Response
{
    public class UpdateExistingResponseRequest
    {
        public int Id { get; set; }
        public string Answers { get; set; }
        public DateTime AnswerDate { get; set; }
        public int SurveyId { get; set; }

    }
}
