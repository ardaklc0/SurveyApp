using SurveyApp.DataTransferObject.Requests.Response;
using SurveyApp.DataTransferObject.Responses.Response;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public class ResponseService : IResponseService
    {
        private readonly IResponseRepository repository;
        public ResponseService(IResponseRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateResponseAsync(CreateNewResponseRequest request)
        {
            var response = new Response
            {
                SurveyId = request.SurveyId,
                Answers = request.Answers,
                AnswerDate = request.AnswerDate,
            };
            await repository.CreateAsync(response);
        }

        public async Task DeleteResponseAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GetResponseDisplayResponse>> GetAllResponsesAsync()
        {
            var responses = await repository.GetAllAsync();
            var displayResponses = responses.Select(response => new GetResponseDisplayResponse
            {
                Id = response.Id,
                SurveyId = response.SurveyId,
                AnswerDate = response.AnswerDate,
                Answers = response.Answers,
            });
            return displayResponses;
        }

        public async Task<IEnumerable<GetResponseDisplayResponse>> GetAllResponsesBySurveyIdAsync(int surveyId)
        {
            var responses = await repository.GetAllAsync();
            var responsesBySurveyId = responses.Where(response => response.SurveyId == surveyId);
            var newResponses = responsesBySurveyId.Select(newResponse => new GetResponseDisplayResponse
            {
                Id = newResponse.Id,
                AnswerDate = newResponse.AnswerDate,
                SurveyId = newResponse.SurveyId,
                Answers = newResponse.Answers
            });
            return newResponses;

        }

        public async Task<GetResponseDisplayResponse> GetResponseAsync(int id)
        {
            var response = await repository.GetAsync(id);
            var displayResponse = new GetResponseDisplayResponse
            {
                Id = response.Id,
                SurveyId = response.SurveyId,
                AnswerDate = response.AnswerDate,
                Answers = response.Answers,
            };
            return displayResponse;
        }

        public async Task<GetResponseDisplayResponse> GetResponseBySurveyIdAsync(int surveyId)
        {
            var responses = await repository.GetAllAsync();
            var bySurvey = responses.FirstOrDefault(response => response.SurveyId == surveyId);
            var displayResponse = new GetResponseDisplayResponse
            {
                Id = bySurvey.Id,
                SurveyId = bySurvey.SurveyId,
                AnswerDate = bySurvey.AnswerDate,
                Answers = bySurvey.Answers,
            };
            return displayResponse;
        }

        public Task UpdateResponseAsync(UpdateExistingResponseRequest request)
        {
            var updatedResponse = new Response
            {
                Id = request.Id,
                AnswerDate = request.AnswerDate,
                Answers = request.Answers,
                SurveyId = request.SurveyId,
            };
            return repository.UpdateAsync(updatedResponse);
        }
    }
}
