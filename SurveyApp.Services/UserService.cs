using SurveyApp.DataTransferObject.Requests.User;
using SurveyApp.DataTransferObject.Responses.User;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateUserAsync(CreateNewUserRequest request)
        {
            var user = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Address = request.Address,
                BirthDate = request.BirthDate,
                Password = request.Password,
                Email = request.Email,
                Role = request.Role
            };
            await repository.CreateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GetUserDisplayResponse>> GetAllUsersAsync()
        {
            var users = await repository.GetAllAsync();
            var responses = users.Select(user => new GetUserDisplayResponse
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Address = user.Address,
                Email = user.Email,
                BirthDate = user.BirthDate,
                Password = user.Password,
                Role = user.Role 
            });
            return responses;
        }

        public async Task<GetUserDisplayResponse> GetUserAsync(int id)
        {
            var user = await repository.GetAsync(id);
            var response = new GetUserDisplayResponse
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Address = user.Address,
                Email = user.Email,
                BirthDate = user.BirthDate,
                Password = user.Password,
                Role = user.Role
            };
            return response;
        }

        public Task UpdateUserAsync(UpdateExistingUserRequest request)
        {
            var updatedUser = new User
            {
                Id = request.Id,
                Name = request.Name,
                Surname = request.Surname,
                Address = request.Address,
                Email = request.Email,
                BirthDate = request.BirthDate,
                Password = request.Password,
                Role = request.Role
            };
            return repository.UpdateAsync(updatedUser);
        }
    }
}
