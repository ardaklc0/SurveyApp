using Newtonsoft.Json.Linq;
using SurveyApp.DataTransferObject.Responses.Question;
using SurveyApp.DataTransferObject.Responses.Survey;

namespace SurveyMVC.Models
{
    public class QuestionDisplayViewModel
    {
        public IEnumerable<GetQuestionDisplayResponse> Questions { get; set; }
        public GetSurveyDisplayResponse Survey { get; set; }
    }
}
