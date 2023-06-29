using SurveyApp.DataTransferObject.Requests.Question;
using SurveyApp.DataTransferObject.Responses.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public interface IQuestionService
    {
        Task<GetQuestionDisplayResponse> GetQuestionAsync(int id);
        Task<IEnumerable<GetQuestionDisplayResponse>> GetAllQuestionsAsync();
        Task<IEnumerable<GetQuestionDisplayResponse>> GetAllQuestionsBySurveyIdAsync(int surveyId);
        Task<GetQuestionDisplayResponse> GetQuestionBySurveyIdAsync(int surveyId);
        Task CreateQuestionAsync(CreateNewQuestionRequest request);
        Task CreateQuestionsAsync(List<CreateNewQuestionRequest> request);  
        Task DeleteQuestionAsync(int id);
        Task UpdateQuestionAsync(UpdateExistingQuestionRequest request);
    }
}
