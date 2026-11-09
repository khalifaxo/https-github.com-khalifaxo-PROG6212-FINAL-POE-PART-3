using Microsoft.AspNetCore.Mvc;
using RaceDay.MVC.Models;
using RaceDay.MVC.Services;

namespace RaceDay.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApiService _apiService;

        public AuthController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _apiService.GetAsync<AuthResponseDto>($"api/auth/login?email={model.Email}&password={model.Password}");

            if (result != null)
            {
                HttpContext.Session.SetString("JWToken", result.Token);
                HttpContext.Session.SetString("UserRole", result.Role);
                HttpContext.Session.SetString("UserName", result.Name);

                if (result.Role == "Organiser")
                    return RedirectToAction("Dashboard", "Organiser");

                return RedirectToAction("Index", "Participant");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }
    }

    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}