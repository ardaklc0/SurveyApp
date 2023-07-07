using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObject.Requests.Response;
using SurveyApp.Services;
using SurveyMVC.Models;
using System.Data;

namespace SurveyMVC.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionService questionService;
        private readonly ISurveyService surveyService;
        public QuestionsController(IQuestionService questionService, ISurveyService surveyService)
        {
            this.questionService = questionService;
            this.surveyService = surveyService;
        }

        public async Task<IActionResult> Index(string token, int surveyId = 1)
        {

            var survey = await surveyService.GetSurveyAsync(surveyId);
            if (survey.Token == token)
            {
                var questions = await questionService.GetAllQuestionsBySurveyIdAsync(surveyId);
                var questionsViewModel = new QuestionDisplayViewModel
                {
                    Questions = questions,
                    Survey = survey
                };
                return View(questionsViewModel);
            }
            return View();

        }

        
    }
}
