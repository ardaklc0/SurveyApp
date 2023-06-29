using SurveyApp.DataTransferObject.Requests.Question;
using SurveyApp.DataTransferObject.Responses.Question;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository repository;
        public QuestionService(IQuestionRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateQuestionAsync(CreateNewQuestionRequest request)
        {
            var question = new Question
            {
                Text = request.Text,
                Options = request.Options,
                SurveyId = request.SurveyId,
                Type = request.Type,
            };
            await repository.CreateAsync(question);
        }

        public async Task CreateQuestionsAsync(List<CreateNewQuestionRequest> request)
        {
            foreach (var questionRequest in request)
            {
                var question = new Question
                {
                    Text = questionRequest.Text,
                    Options = questionRequest.Options,
                    SurveyId = questionRequest.SurveyId,
                    Type = questionRequest.Type,
                };
                await repository.CreateAsync(question);
            }
        }

        public async Task DeleteQuestionAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GetQuestionDisplayResponse>> GetAllQuestionsAsync()
        {
            var questions = await repository.GetAllAsync();
            var responses = questions.Select(question => new GetQuestionDisplayResponse
            {
                Id = question.Id,
                Text = question.Text,
                Options = question.Options,
                SurveyId = question.SurveyId,
                Type = question.Type,
            });
            return responses;
        }

        public async Task<IEnumerable<GetQuestionDisplayResponse>> GetAllQuestionsBySurveyIdAsync(int surveyId)
        {
            var questions = await repository.GetAllAsync();
            var questionsBySurveyId = questions.Where(question => question.SurveyId == surveyId);
            var newQuestions = questionsBySurveyId.Select(newQuestion => new GetQuestionDisplayResponse
            {
                Id = newQuestion.Id,
                Text = newQuestion.Text,
                Options = newQuestion.Options,
                SurveyId = newQuestion.SurveyId,
                Type = newQuestion.Type,
            });
            return newQuestions;
        }

        public async Task<GetQuestionDisplayResponse> GetQuestionAsync(int id)
        {
            var question = await repository.GetAsync(id);
            var response = new GetQuestionDisplayResponse
            {
                Id = question.Id,
                Text = question.Text,
                Options = question.Options,
                SurveyId = question.SurveyId,
                Type = question.Type,
            };
            return response;
        }

        public async Task<GetQuestionDisplayResponse> GetQuestionBySurveyIdAsync(int surveyId)
        {
            var questions = await repository.GetAllAsync();
            var bySurvey = questions.FirstOrDefault(question => question.SurveyId == surveyId);
            var displayResponse = new GetQuestionDisplayResponse
            {
                Id = bySurvey.Id,
                Text = bySurvey.Text,
                Options = bySurvey.Options,
                SurveyId = bySurvey.SurveyId,
                Type = bySurvey.Type,
            };
            return displayResponse;
        }

        public Task UpdateQuestionAsync(UpdateExistingQuestionRequest request)
        {
            var updatedQuestion = new Question
            {
                Id = request.Id,
                Text = request.Text,
                Options = request.Options,
                SurveyId = request.SurveyId,
                Type = request.Type
            };
            return repository.UpdateAsync(updatedQuestion);
        }
    }
}
