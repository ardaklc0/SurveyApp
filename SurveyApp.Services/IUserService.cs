using SurveyApp.DataTransferObject.Requests.User;
using SurveyApp.DataTransferObject.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public interface IUserService
    {
        Task<GetUserDisplayResponse> GetUserAsync(int id);
        Task<IEnumerable<GetUserDisplayResponse>> GetAllUsersAsync();
        Task CreateUserAsync(CreateNewUserRequest request);
        Task DeleteUserAsync(int id);
        Task UpdateUserAsync(UpdateExistingUserRequest request);
    }
}
