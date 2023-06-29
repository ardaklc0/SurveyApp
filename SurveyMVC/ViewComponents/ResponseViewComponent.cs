using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using SurveyApp.DataTransferObject.Responses.Response;
using SurveyApp.Services;

namespace SurveyMVC.ViewComponents
{
    public class ResponseViewComponent : ViewComponent
    {
        private readonly IResponseService service;
        public ResponseViewComponent(IResponseService service)
        {
            this.service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(GetResponseDisplayResponse item)
        {
            return View(item);
        }
    }
}
