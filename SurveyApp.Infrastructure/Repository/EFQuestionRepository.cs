using Microsoft.EntityFrameworkCore;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Repository
{
    public class EFQuestionRepository : IQuestionRepository
    {
        private readonly SurveyDbContext context;
        public EFQuestionRepository(SurveyDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Question entity)
        {
            await context.Questions.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingQuestion = await context.Questions.FindAsync(id);
            if (deletingQuestion != null)
            {
                context.Questions.Remove(deletingQuestion);
            }
            await context.SaveChangesAsync();
        }

        public async Task<List<Question>> GetAllAsync()
        {
            return await context.Questions.AsNoTracking().ToListAsync();
        }

        public async Task<Question> GetAsync(int id)
        {

            return await context.Questions.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task UpdateAsync(Question entity)
        {
            context.Questions.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
