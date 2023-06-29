using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObject.Requests.Response;
using SurveyApp.Services;
using SurveyMVC.Models;

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

        public async Task<IActionResult> Index(int surveyId = 1)
        {
            var questions = await questionService.GetAllQuestionsBySurveyIdAsync(surveyId);
            var survey = await surveyService.GetSurveyAsync(surveyId);
            var questionsViewModel = new QuestionDisplayViewModel
            {
                Questions = questions,
                Survey = survey
            };
            return View(questionsViewModel);
        }

        
    }
}
