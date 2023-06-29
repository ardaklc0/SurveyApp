using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Data
{
    public static class DbSeeding
    {
        public static void SeedDatabase(SurveyDbContext dbContext)
        {
            seedUserIfNotExist(dbContext);
            seedSurveyIfNotExist(dbContext);
            seedQuestionIfNotExist(dbContext);
            seedResponseIfNotExist(dbContext);
        }

        private static void seedUserIfNotExist(SurveyDbContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                var user = new User
                {
                    Name = "Arda",
                    Surname = "Kılıç",
                    Email = "ardaklc0@gmail.com",
                    Address = "Beylerbeyi",
                    BirthDate = DateTime.Parse("13-06-2023"),
                    Role = "Admin",
                    Password = "123"
                };
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
        }

        private static void seedSurveyIfNotExist(SurveyDbContext dbContext)
        {
            if (!dbContext.Surveys.Any())
            {
                var survey = new Survey
                {
                    Title = "Memnuniyet Anketi",
                    Description = "Çalışanlarımız bizden ne kadar memnun?",
                    CreationDate = DateTime.Now,
                    UserId = 1
                };
                dbContext.Surveys.Add(survey);
                dbContext.SaveChanges();
            }
        }

        private static void seedQuestionIfNotExist(SurveyDbContext dbContext)
        {
            if (!dbContext.Questions.Any())
            {
                var question = new List<Question>
                {
                    new() {Text = "Yemeklerden memnun musunuz?", Type = "radio", Options = "[{\"text\": \"Evet\"}, {\"text\": \"Hayır\"}]", SurveyId = 1},
                    new() {Text = "En sevdiğiniz yemek hangisi?", Type = "checkbox", Options = "[{\"text\": \"Mantı\"},{\"text\": \"Hamburger\"},{\"text\":\"Pizza\"}]", SurveyId = 1},
                    new() {Text = "Yemeklerden ne kadar memnunsunuz?", Type = "rating", SurveyId = 1}
                };
                dbContext.Questions.AddRange(question);
                dbContext.SaveChanges();
            }
        }

        private static void seedResponseIfNotExist(SurveyDbContext dbContext)
        {
            if (!dbContext.Responses.Any())
            {
                var responses = new List<Response>
                {
                    new() {Answers = "[{\"id\": 1, \"answer\": \"Evet\"}, {\"id\": 2, \"answer\": \"Hamburger\"}, {\"id\": 3, \"answer\": \"7\"}]", AnswerDate = DateTime.Now, SurveyId = 1},
                    new() {Answers = "[{\"id\":1, \"answer\": \"Evet\"}, {\"id\": 2, \"answer\": \"Mantı\"}, {\"id\": 3, \"answer\": \"8\"}]", AnswerDate = DateTime.Now, SurveyId = 1}
                };
                dbContext.Responses.AddRange(responses);
                dbContext.SaveChanges();
            }
        }
    }
}

//new() { Answer = "Evet", AnswerDate = DateTime.Now, QuestionId = 1, SurveyId = 1 },
//new() { Answer = "Hamburger", AnswerDate = DateTime.Now, QuestionId = 2, SurveyId = 1 },
//new() { Answer = "8", AnswerDate = DateTime.Now, QuestionId = 3, SurveyId = 1 },

//new() { Answer = "Evet", AnswerDate = DateTime.Now, QuestionId = 1, SurveyId = 1 },
//new() { Answer = "Mantı", AnswerDate = DateTime.Now, QuestionId = 2, SurveyId = 1 },
//new() { Answer = "7", AnswerDate = DateTime.Now, QuestionId = 3, SurveyId = 1 },