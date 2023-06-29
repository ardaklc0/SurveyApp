using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Entities
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string? Options { get; set; }
        public Survey Survey { get; set; }
        public int SurveyId { get; set; }
        public List<Response>? Responses { get; set; }
    }
}
