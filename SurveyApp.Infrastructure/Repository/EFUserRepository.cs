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
    public class EFUserRepository : IUserRepository
    {
        private readonly SurveyDbContext context;
        public EFUserRepository(SurveyDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(User entity)
        {
            await context.Users.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingUser = await context.Users.FindAsync(id);
            if (deletingUser != null)
            {
                context.Users.Remove(deletingUser);
            }
            await context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            return await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateAsync(User entity)
        {
            context.Users.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
