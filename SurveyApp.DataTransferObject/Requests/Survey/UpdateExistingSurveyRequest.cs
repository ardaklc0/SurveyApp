using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObject.Requests.Survey
{
    public class UpdateExistingSurveyRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public string Token { get; set; }
        public int UserId { get; set; }
    }
}
