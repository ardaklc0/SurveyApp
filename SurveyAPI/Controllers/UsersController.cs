using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using SurveyAPI.Models;
using SurveyApp.DataTransferObject.Requests.User;
using SurveyApp.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace SurveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService service;
        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await service.GetAllUsersAsync();
            return Ok(users);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await service.GetUserAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateNewUserRequest request)
        {
            await service.CreateUserAsync(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateExistingUserRequest request)
        {
            await service.UpdateUserAsync(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await service.DeleteUserAsync(id);
            return Ok();
        }


        [HttpPost("[action]"), AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginViewModel userLogin)
        {
            if (ModelState.IsValid)
            {
                var user =  await service.ValidateUserAsync(userLogin.UserName, userLogin.Password);
                if (user != null)
                {
                    Claim[] claims = new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Name),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SurveySecretWord"));
                    var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        issuer: "server",
                        audience: "client",
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: credential
                    );
                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                ModelState.AddModelError("login", "Username or password is wrong");
            }
            return BadRequest(ModelState);
        }
    }
}
