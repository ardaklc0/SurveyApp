using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObject.Requests.Survey;
using SurveyApp.Entities;
using SurveyApp.Services;

namespace SurveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveyService service;
        public SurveysController(ISurveyService service)
        {
            this.service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetSurveys()
        {
            var surveys = await service.GetAllSurveysAsync();
            return Ok(surveys); 
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSurvey(int id)
        {
            var survey = await service.GetSurveyAsync(id);
            return Ok(survey);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSurvey(CreateNewSurveyRequest request)
        {
            var createdSurvey = await service.CreateSurveyAsync(request);
            int surveyId = createdSurvey.Id;
            string redirectUrl = GenerateRedirectUrl(surveyId);
            return Ok(redirectUrl);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSurvey(int id, UpdateExistingSurveyRequest request)
        {
            await service.UpdateSurveyAsync(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            await service.DeleteSurveyAsync(id);
            return Ok();
        }


        string GenerateRedirectUrl(int surveyId)
        {
            var request = HttpContext.Request;
            string baseUrl = $"{request.Scheme}://localhost:7052";
            string controllerName = "Questions";
            string actionName = "Index";
            string redirectUrl = $"{baseUrl}/{controllerName}/{actionName}?surveyId={surveyId}";
            return redirectUrl;
        }
    }
}
