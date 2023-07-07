using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Entities
{
    public class Survey : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string? Token { get; set; }
        public List<Question>? Questions { get; set; }
        public List<Response>? Responses { get; set; }
    }
}
