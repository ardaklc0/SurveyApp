using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObject.Requests.Question;
using SurveyApp.Services;

namespace SurveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService service;
        public QuestionsController(IQuestionService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            var questions = await service.GetAllQuestionsAsync();
            return Ok(questions);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var question = await service.GetQuestionAsync(id);
            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateNewQuestionRequest request)
        {
            await service.CreateQuestionAsync(request);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateQuestions(List<CreateNewQuestionRequest> requests)
        {
            await service.CreateQuestionsAsync(requests);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, UpdateExistingQuestionRequest request)
        {
            await service.UpdateQuestionAsync(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await service.DeleteQuestionAsync(id);
            return Ok();
        }
    }
}
