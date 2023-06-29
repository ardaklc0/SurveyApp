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
    public class EFResponseRepository : IResponseRepository
    {
        private readonly SurveyDbContext context;
        public EFResponseRepository(SurveyDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Response entity)
        {
            await context.Responses.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingResponse = await context.Responses.FindAsync(id);
            if (deletingResponse != null)
            {
                context.Responses.Remove(deletingResponse);
            }
            await context.SaveChangesAsync();
        }

        public async Task<List<Response>> GetAllAsync()
        {
            return await context.Responses.AsNoTracking().ToListAsync();
        }

        public async Task<Response> GetAsync(int id)
        {
            return await context.Responses.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateAsync(Response entity)
        {
            context.Responses.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
