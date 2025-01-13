using DataAccess.Postgres.Repositories.IRepository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DataAccess.Postgres.Entity;
using Microsoft.AspNetCore.Identity;

namespace MyProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Страница входа
        [HttpGet("/login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        // Обработка логина
        [HttpPost("/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string username, string password, string? returnUrl = null)
        {
            var user = (await _userRepository.GetAllAsync())
                .FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                ModelState.AddModelError("", "Неверное имя пользователя или пароль.");
                return View();
            }

            // Проверяем хэш пароля
            var passwordHasher = new PasswordHasher<UserEntity>();
            var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);

            if (result != PasswordVerificationResult.Success)
            {
                ModelState.AddModelError("", "Неверное имя пользователя или пароль.");
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name ?? "user"),
                new Claim("PersonName", user.PersonName),
                new Claim("PersonSurname", user.PersonSurname),
                new Claim("PersonPatronymic", user.PersonPatronymic)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("MainPage", "Home"); 
        }

        // Выход
        [HttpGet("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
