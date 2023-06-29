using Newtonsoft.Json.Linq;
using SurveyApp.DataTransferObject.Responses.Question;
using SurveyApp.DataTransferObject.Responses.Response;
using SurveyApp.DataTransferObject.Responses.Survey;
using System.Text.Json.Nodes;

namespace SurveyMVC.Models
{
    public class GraphicViewModel
    {
        public IEnumerable<GetResponseDisplayResponse> Responses { get; set; }
        public GetSurveyDisplayResponse Survey { get; set; }
        public IEnumerable<GetQuestionDisplayResponse> Questions { get; set; }
        public List<string> ResponsesByQuestionId(int questionId)
        {
            List<string> questionIds = new List<string>();
            foreach (var item in Responses)
            {
                string json = item.Answers;
                JArray jsonArray = JArray.Parse(json);
                foreach (var obj in jsonArray)
                {
                    if (obj["id"].ToString() == questionId.ToString())
                    {
                        questionIds.Add(obj["answer"].ToString());
                    }
                }
            }
            return questionIds;
        }

        public Dictionary<string, int> CountEachResponses(int questionId)
        {
            var newList = new Dictionary<string, int>();
            var responseList = ResponsesByQuestionId(questionId);
            var groups = responseList.GroupBy(item => item)
                                     .Select(group => new { Value = group.Key, Count = group.Count() });
            foreach (var group in groups)
            {
                newList.Add(group.Value, group.Count);
            }
            return newList;
        }
    }
}
