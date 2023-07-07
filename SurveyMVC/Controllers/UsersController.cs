using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SurveyApp.Services;
using SurveyMVC.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SurveyMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(UserLoginViewModel userLogin)
        {
            if (ModelState.IsValid)
            {
                var user = await service.ValidateUserAsync(userLogin.UserName, userLogin.Password);
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
                    var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);
                    if (generatedToken != null)
                    {
                        HttpContext.Session.SetString("JWTToken", generatedToken);
                    }
                    return RedirectToAction("Index", "Home", new {token = generatedToken});
                }
                ModelState.AddModelError("login", "Username or password is wrong");
            }
            return View();
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
