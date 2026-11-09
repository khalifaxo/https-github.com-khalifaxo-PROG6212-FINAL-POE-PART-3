using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using RaceDay.MVC.Models;

namespace RaceDay.MVC.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7001/");
        }

        public async Task<T?> GetAsync<T>(string endpoint, string? token = null)
        {
            AddAuthorization(token);
            var response = await _httpClient.GetAsync(endpoint);
            if (!response.IsSuccessStatusCode) return default;
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<bool> PostAsync<T>(string endpoint, T data, string? token = null)
        {
            AddAuthorization(token);
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(endpoint, content);
            return response.IsSuccessStatusCode;
        }

        private void AddAuthorization(string? token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = !string.IsNullOrEmpty(token)
                ? new AuthenticationHeaderValue("Bearer", token)
                : null;
        }
    }
}