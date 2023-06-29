using SurveyApp.DataTransferObject.Requests.Survey;
using SurveyApp.DataTransferObject.Responses.Survey;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository repository;
        public SurveyService(ISurveyRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Survey> CreateSurveyAsync(CreateNewSurveyRequest request)
        {
            var survey = new Survey
            {
                Title = request.Title,
                CreationDate = request.CreationDate,
                Description = request.Description,
                UpdateDate = request.UpdateDate,
                UserId = request.UserId,
            };
            await repository.CreateAsync(survey);
            return survey;
        }

        public async Task DeleteSurveyAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GetSurveyDisplayResponse>> GetAllSurveysAsync()
        {
            var surveys = await repository.GetAllAsync();
            var responses = surveys.Select(survey => new GetSurveyDisplayResponse
            {
                Id = survey.Id,
                Title = survey.Title,
                CreationDate = survey.CreationDate,
                Description = survey.Description,
                UpdateDate = survey.UpdateDate,
                UserId = survey.UserId
            });
            return responses;
        }

        public async Task<GetSurveyDisplayResponse> GetSurveyAsync(int id)
        {
            var survey = await repository.GetAsync(id);
            var response = new GetSurveyDisplayResponse
            {
                Id = survey.Id,
                Title = survey.Title,
                CreationDate = survey.CreationDate,
                Description = survey.Description,
                UpdateDate = survey.UpdateDate,
                UserId = survey.UserId
            };
            return response;
        }

        public Task UpdateSurveyAsync(UpdateExistingSurveyRequest request)
        {
            var updatedSurvey = new Survey
            {
                Id = request.Id,
                Title = request.Title,
                CreationDate = request.CreationDate,
                Description = request.Description,
                UpdateDate = request.UpdateDate,
                UserId = request.UserId
            };
            return repository.UpdateAsync(updatedSurvey);
            
        }
    }
}
