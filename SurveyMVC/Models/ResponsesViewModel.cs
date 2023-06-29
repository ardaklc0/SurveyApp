using Newtonsoft.Json.Linq;
using SurveyApp.DataTransferObject.Responses.Response;
using SurveyApp.DataTransferObject.Responses.Survey;

namespace SurveyMVC.Models
{
    public class ResponsesViewModel
    {
        public IEnumerable<GetResponseDisplayResponse> Responses { get; set; }
        public GetSurveyDisplayResponse Survey { get; set; }

        public int ResponseNumber() 
        {
            var count = 0;
            foreach (var item in Responses)
            {
                string json = item.Answers;
                JArray jsonArray = JArray.Parse(json);
                count = jsonArray.Count;
                return count;
            }
            return count;
        }
    }
}
