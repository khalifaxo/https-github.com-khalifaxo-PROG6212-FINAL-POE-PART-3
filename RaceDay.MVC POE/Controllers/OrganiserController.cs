using Microsoft.AspNetCore.Mvc;
using RaceDay.MVC.Models;
using RaceDay.MVC.Services;

namespace RaceDay.MVC.Controllers
{
    public class OrganiserController : Controller
    {
        private readonly ApiService _apiService;

        public OrganiserController(ApiService apiService)
        {
            _apiService = apiService;
        }

        private string? Token => HttpContext.Session.GetString("JWToken");

        public async Task<IActionResult> Dashboard()
        {
            if (HttpContext.Session.GetString("UserRole") != "Organiser") return RedirectToAction("Login", "Auth");

            var events = await _apiService.GetAsync<List<EventViewModel>>("api/events/organiser", Token);
            return View(events ?? new());
        }
    }
}