using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Repository
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
    }
}
