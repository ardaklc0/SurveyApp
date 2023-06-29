using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObject.Responses.Question;
using SurveyApp.Services;

namespace SurveyMVC.ViewComponents
{
    public class QuestionViewComponent : ViewComponent
    {
        private readonly IQuestionService service;
        public QuestionViewComponent(IQuestionService service)
        {
            this.service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(GetQuestionDisplayResponse item)
        {
            return View(item);
        }
    }
}
