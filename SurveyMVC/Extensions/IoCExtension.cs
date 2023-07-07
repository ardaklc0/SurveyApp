using Microsoft.EntityFrameworkCore;
using SurveyApp.Infrastructure.Data;
using SurveyApp.Infrastructure.Repository;
using SurveyApp.Services;

namespace SurveyMVC.Extensions
{
    public static class IoCExtension
    {
        public static IServiceCollection AddInjections(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, EFUserRepository>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IQuestionRepository, EFQuestionRepository>();
            services.AddScoped<IResponseService, ResponseService>();
            services.AddScoped<IResponseRepository, EFResponseRepository>();
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<ISurveyRepository, EFSurveyRepository>();

            services.AddDbContext<SurveyDbContext>(opt => opt.UseSqlServer(connectionString));

            return services;
        }
    }
}
