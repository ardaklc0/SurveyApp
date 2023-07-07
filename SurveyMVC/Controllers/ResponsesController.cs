using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObject.Requests.Response;
using SurveyApp.Services;
using SurveyMVC.Models;
using System.Data;
using System.Reflection.Metadata;

namespace SurveyMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ResponsesController : Controller
    {
        private readonly IResponseService responseService;
        private readonly ISurveyService surveyService;
        private readonly IQuestionService questionService;
        public ResponsesController(IResponseService responseService, ISurveyService surveyService, IQuestionService questionService)
        {
            this.responseService = responseService;
            this.surveyService = surveyService;
            this.questionService = questionService; 
        }

        public async Task<IActionResult> Index(int surveyId = 1)
        {
            var responses = await responseService.GetAllResponsesBySurveyIdAsync(surveyId);
            var survey = await surveyService.GetSurveyAsync(surveyId);
            var responseViewModel = new ResponsesViewModel
            {
                Responses = responses,
                Survey = survey
            };
            return View(responseViewModel);
        }

        public async Task<IActionResult> Graphic(int surveyId = 1)
        {
            var responses = await responseService.GetAllResponsesBySurveyIdAsync(surveyId);
            var survey = await surveyService.GetSurveyAsync(surveyId);
            var questions = await questionService.GetAllQuestionsBySurveyIdAsync(surveyId);
            var graphicViewModel = new GraphicViewModel
            {
                Questions = questions,
                Responses = responses,
                Survey = survey
            };
            return View(graphicViewModel);

        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Submit([FromBody] CreateNewResponseRequest request)
        {
            if (ModelState.IsValid)
            {
                await responseService.CreateResponseAsync(request);
                return Json(request);
            }
            return BadRequest(ModelState.Keys.SelectMany(key => ModelState[key].Errors));

        }
    }
}
