using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObject.Requests.Response;
using SurveyApp.Services;

namespace SurveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ResponsesController : ControllerBase
    {
        private readonly IResponseService service;
        public ResponsesController(IResponseService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetResponses()
        {
            var responses = await service.GetAllResponsesAsync();
            return Ok(responses);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetResponse(int id)
        {
            var response = await service.GetResponseAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResponse(CreateNewResponseRequest request)
        {
            await service.CreateResponseAsync(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResponse(int id, UpdateExistingResponseRequest request)
        {
            await service.UpdateResponseAsync(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponse(int id)
        {
            await service.DeleteResponseAsync(id);
            return Ok();
        }
    }
}
