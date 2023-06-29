using SurveyApp.DataTransferObject.Requests.Survey;
using SurveyApp.DataTransferObject.Responses.Survey;
using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public interface ISurveyService
    {
        Task<GetSurveyDisplayResponse> GetSurveyAsync(int id);
        Task<IEnumerable<GetSurveyDisplayResponse>> GetAllSurveysAsync();
        Task<Survey> CreateSurveyAsync(CreateNewSurveyRequest request);
        Task DeleteSurveyAsync(int id);
        Task UpdateSurveyAsync(UpdateExistingSurveyRequest request);
    }
}
