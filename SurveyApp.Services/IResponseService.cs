using SurveyApp.DataTransferObject.Requests.Question;
using SurveyApp.DataTransferObject.Requests.Response;
using SurveyApp.DataTransferObject.Responses.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public interface IResponseService
    {
        Task<GetResponseDisplayResponse> GetResponseAsync(int id);
        Task<GetResponseDisplayResponse> GetResponseBySurveyIdAsync(int surveyId);
        Task<IEnumerable<GetResponseDisplayResponse>> GetAllResponsesAsync();
        Task<IEnumerable<GetResponseDisplayResponse>> GetAllResponsesBySurveyIdAsync(int surveyId);
        Task CreateResponseAsync(CreateNewResponseRequest request);
        Task DeleteResponseAsync(int id);
        Task UpdateResponseAsync(UpdateExistingResponseRequest request);
    }
}
