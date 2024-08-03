using System.Net.Http.Json;
using GessiWebApp.Web.Models;

namespace GessiWebApp.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AuthResult> Register(RegisterModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/register", model);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AuthResult>();
                return result;
            }
            return new AuthResult { Succeeded = false, Message = "Registration failed" };
        }

        public async Task<AuthResult> Login(LoginModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", model);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AuthResult>();
                return result;
            }
            return new AuthResult { Succeeded = false, Message = "Login failed" };
        }
    }
}